using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class HomeAutomation : IDisposable
    {
        private Uri host = new Uri("http://fritz.box");
        private HttpClientHandler handler;
        private HttpClient client;
        private string sessionId;

        public HomeAutomation(string login, string password)
        {
            // connect
            this.handler = new HttpClientHandler();
            this.handler.CookieContainer = new System.Net.CookieContainer();
            this.handler.UseCookies = true;
            this.client = new HttpClient(this.handler);
            this.client.BaseAddress = host;

            // get session id
            //this.sessionId = GetSessionIdAsync(login, password).Result;
            this.sessionId = GetSessionId(login, password);
        }

        public void Dispose()
        {
            
        }

        #region Public Methods

        /// <summary>
        /// Returns the AIN / MAC list of all known sockets.
        /// </summary>
        /// <returns>AIN / MAC list</returns>
        public string[] GetSwitchList()
        {
            string list = Get("getswitchlist");
            return list.TrimEnd().Split(',');
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOn(string ain)
        {
            string res = Get(ain, "setswitchon");
            return res == "1";
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOff(string ain)
        {
            string res = Get(ain, "setswitchoff");
            return res == "1";
        }
        
        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetsSwitchToggle(string ain)
        {
            string res = Get(ain, "setswitchtoggle");
            return res == "1";
        }

        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>State of the socket</returns>
        public bool GetSwitchState(string ain)
        {
            string res = Get(ain, "getswitchstate");
            return res == "1";
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>True if connected; false if not</returns>
        public bool GetSwitchPresent(string ain)
        {
            string res = Get(ain, "getswitchpresent");
            return res == "1";
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Power in mW, "inval" if unknown.</returns>
        public int GetSwitchPower(string ain)
        {
            string res = Get(ain, "getswitchpower");
            return int.Parse(res);
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Energy in Wh, "inval" if unknown.</returns>
        public int GetSwitchEnergy(string ain)
        {
            string res = Get(ain, "getswitchenergy");
            return int.Parse(res);
        }

        /// <summary>
        /// Returns identifiers of the actor.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Name of the actor</returns>
        public string GetSwitchName(string ain)
        {
            return Get(ain, "getswitchname");
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>Information of all SmartHome devices</returns>
        public DeviceList GetDeviceListInfos()
        {
            string res = Get("getdevicelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            var value = (DeviceList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C.</returns>
        public string GetTemperature(string ain)
        {
            return Get(ain, "gettemperature");
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &le;= 8 ° C, 17 =, 5 ° C ...... 56 &gr;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public string GetHkrtSoll(string ain)
        {
            return Get(ain, "gethkrtsoll");
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &le;= 8 ° C, 17 =, 5 ° C ...... 56 &gr;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public string GetHkrKomfort(string ain)
        {
            return Get(ain, "gethkrkomfort");
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &le;= 8 ° C, 17 =, 5 ° C ...... 56 &gr;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public string GetHkrAbsenk(string ain)
        {
            return Get(ain, "gethkrabsenk");
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain"></param>
        /// <param name="value">Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 <= 8 ° C, 17 = 8.5 ° C...... 56> = 28 ° C 254 = ON, 253 = OFF</param>
        /// <returns></returns>
        public void SetHkrtSoll(string ain, string value)
        {
            Get(ain, "sethkrtsoll", value);
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public DeviceStats GetBasicDeviceStats(string ain)
        {
            string res = Get(ain, "getbasicdevicestats");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceStats));
            var value = (DeviceStats)serializer.Deserialize(new StringReader(res));
            return value;
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public TemplateList GetTemplateListInfos(string ain)
        {
            string res = Get(ain, "gettemplatelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(TemplateList));
            var value = (TemplateList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        /// <summary>
        /// Returns the basic information of all templates / templates. Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public void ApplyTemplate(string ain)
        {
            Get(ain, "applytemplate");
        }

        #endregion

        #region Public Async Methods

        public async Task<string[]> GetSwitchListAsync()
        {
            string list = await GetAsync("getswitchlist");
            return list.TrimEnd().Split(',');
        }

        public async Task<bool> SetSwitchOnAsync(string ain)
        {
            string res = await GetAsync(ain, "setswitchon");
            return res == "1";
        }
        
        public async Task<bool> SetSwitchOffAsync(string ain)
        {
            string res = await GetAsync(ain, "setswitchoff");
            return res == "1";
        }
        public async Task<bool> SetsSwitchToggleAsync(string ain)
        {
            string res = await GetAsync(ain, "setswitchtoggle");
            return res == "1";
        }

        public async Task<bool> GetSwitchStateAsync(string ain)
        {
            string res = await GetAsync(ain, "getswitchstate");
            return res == "1";
        }

        public async Task<bool> GetSwitchPresentAsync(string ain)
        {
            string res = await GetAsync(ain, "getswitchpresent");
            return res == "1";
        }

        public async Task<int> GetSwitchPowerAsync(string ain)
        {
            string res = await GetAsync(ain, "getswitchpower");
            return int.Parse(res);
        }

        public async Task<int> GetSwitchEnergyAsync(string ain)
        {
            string res = await GetAsync(ain, "getswitchenergy");
            return int.Parse(res);
        }

        public async Task<string> GetSwitchNameAsync(string ain)
        {
            return await GetAsync(ain, "getswitchname");
        }

        public async Task<DeviceList> GetDeviceListInfosAsync()
        {
            string res = await GetAsync("getdevicelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            var value = (DeviceList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public async Task<string> GetTemperatureAsync(string ain)
        {
            return await GetAsync(ain, "gettemperature");
        }

        public async Task<string> GetHkrtSollAsync(string ain)
        {
            return await GetAsync(ain, "gethkrtsoll");
        }

        public async Task<string> GetHkrKomfortAsync(string ain)
        {
            return await GetAsync(ain, "gethkrkomfort");
        }

        public async Task<string> GetHkrAbsenkAsync(string ain)
        {
            return await GetAsync(ain, "gethkrabsenk");
        }

        public async Task<string> SetHkrtSollAsync(string ain, string value)
        {
            return await GetAsync(ain, "sethkrtsoll", value);
        }

        public async Task<DeviceStats> GetBasicDeviceStatsAsync(string ain)
        {
            string res = await GetAsync(ain, "getbasicdevicestats");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceStats));
            var value = (DeviceStats)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public async Task<TemplateList> GetTemplateListInfosAsync(string ain)
        {
            string res = await GetAsync(ain, "gettemplatelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(TemplateList));
            var value = (TemplateList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public async Task<string> ApplyTemplateAsync(string ain)
        {
            return await GetAsync(ain, "applytemplate");
        }

        #endregion

        #region Private Methods

        private string GetSessionId(string login, string password)
        {
            string sessionId;
            string challenge;

            using (HttpResponseMessage response = this.client.GetAsync("login_sid.lua").Result)
            {
                response.EnsureSuccessStatusCode();
                Stream stream = response.Content.ReadAsStreamAsync().Result;
                XDocument doc = XDocument.Load(stream);
                XElement info = doc.FirstNode as XElement;
                sessionId = info.Element("SID").Value;
                challenge = info.Element("Challenge").Value;
            }

            if (sessionId == "0000000000000000")
            {
                string resp = $"{challenge}-{GetMD5Hash(challenge + "-" + password)}";
                string request = $"login_sid.lua?username={login}&response={resp}";
                using (HttpResponseMessage response = this.client.GetAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    Stream stream = response.Content.ReadAsStreamAsync().Result;
                    XDocument doc = XDocument.Load(stream);
                    XElement info = doc.FirstNode as XElement;
                    sessionId = info.Element("SID").Value;
                }
            }
            return sessionId;
        }

        private async Task<string> GetSessionIdAsync(string login, string password)
        {
            string sessionId;
            string challenge;

            using (HttpResponseMessage response = await this.client.GetAsync("login_sid.lua"))
            {
                response.EnsureSuccessStatusCode();
                Stream stream = await response.Content.ReadAsStreamAsync();
                XDocument doc = XDocument.Load(stream);
                XElement info = doc.FirstNode as XElement;
                sessionId = info.Element("SID").Value;
                challenge = info.Element("Challenge").Value;
            }

            if (sessionId == "0000000000000000")
            {
                string resp = $"{challenge}-{GetMD5Hash(challenge + "-" + password)}";
                string request = $"login_sid.lua?username={login}&response={resp}";
                using (HttpResponseMessage response = await this.client.GetAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    XDocument doc = XDocument.Load(stream);
                    XElement info = doc.FirstNode as XElement;
                    sessionId = info.Element("SID").Value;
                }
            }
            return sessionId;
        }

        private string GetMD5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sb.Append(data[i].ToString("x2"));
            //}
            //return sb.ToString();
            return data.Select(d => d.ToString("x2")).Aggregate((a, b) => a + b);
        }

        //private string GetSessionId(string login, string password)
        //{
        //    XDocument doc = XDocument.Load(new Uri(this.host, "login_sid.lua").ToString());
        //    XElement info = doc.FirstNode as XElement;
        //    return info.Element("SID").Value;
        //}

        private string Get(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetAsync(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string Get(string ain, string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetAsync(string ain, string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string Get(string ain, string cmd, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetAsync(string ain, string cmd, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        #endregion
    }
}
