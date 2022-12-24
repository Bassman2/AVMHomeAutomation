using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            return GetString("getswitchlist").TrimEnd().Split(',');
        }

        public async Task<string[]> GetSwitchListAsync()
        {
            string list = await GetStringAsync("getswitchlist");
            return list.TrimEnd().Split(',');
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOn(string ain)
        {
            return GetBool("setswitchon", ain);
        }

        public async Task<bool> SetSwitchOnAsync(string ain)
        {
            return await GetBoolAsync(ain, "setswitchon");
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOff(string ain)
        {
            return GetBool("setswitchoff", ain);
        }

        public async Task<bool> SetSwitchOffAsync(string ain)
        {
            return await GetBoolAsync(ain, "setswitchoff");
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>New state of the socket</returns>
        public bool SetsSwitchToggle(string ain)
        {
            return GetBool("setswitchtoggle", ain);
        }

        public async Task<bool> SetsSwitchToggleAsync(string ain)
        {
            return await GetBoolAsync(ain, "setswitchtoggle");
        }


        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>State of the socket</returns>
        public bool GetSwitchState(string ain)
        {
            return GetBool("getswitchstate", ain);
        }

        public async Task<bool> GetSwitchStateAsync(string ain)
        {
            return await GetBoolAsync(ain, "getswitchstate");
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>True if connected; false if not</returns>
        public bool GetSwitchPresent(string ain)
        {
            return GetBool("getswitchpresent", ain);
        }

        public async Task<bool> GetSwitchPresentAsync(string ain)
        {
            return await GetBoolAsync(ain, "getswitchpresent");
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Power in mW, "inval" if unknown.</returns>
        public int GetSwitchPower(string ain)
        {
            return GetInt("getswitchpower", ain);
        }

        public async Task<int> GetSwitchPowerAsync(string ain)
        {
            return await GetIntAsync(ain, "getswitchpower");
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Energy in Wh, "inval" if unknown.</returns>
        public int GetSwitchEnergy(string ain)
        {
            return GetInt("getswitchenergy", ain);
        }

        public async Task<int> GetSwitchEnergyAsync(string ain)
        {
            return await GetIntAsync(ain, "getswitchenergy");
        }

        /// <summary>
        /// Returns identifiers of the actor.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Name of the actor</returns>
        public string GetSwitchName(string ain)
        {
            return GetString("getswitchname", ain);
        }

        public async Task<string> GetSwitchNameAsync(string ain)
        {
            return await GetStringAsync(ain, "getswitchname");
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>Information of all SmartHome devices</returns>
        public DeviceList GetDeviceListInfos()
        {
            return GetAs<DeviceList>("getdevicelistinfos");
        }

        public async Task<DeviceList> GetDeviceListInfosAsync()
        {
            return await GetAsAsync<DeviceList>("getdevicelistinfos");
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C.</returns>
        public int GetTemperature(string ain)
        {
            return GetInt("gettemperature", ain);
        }

        public async Task<string> GetTemperatureAsync(string ain)
        {
            return await GetStringAsync("gettemperature", ain);
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrtSoll(string ain)
        {
            return GetInt("gethkrtsoll", ain);
        }

        public async Task<string> GetHkrtSollAsync(string ain)
        {
            return await GetStringAsync("gethkrtsoll", ain);
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrKomfort(string ain)
        {
            return GetInt("gethkrkomfort", ain);
        }

        public async Task<string> GetHkrKomfortAsync(string ain)
        {
            return await GetStringAsync("gethkrkomfort", ain);
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrAbsenk(string ain)
        {
            return GetInt("gethkrabsenk", ain);
        }

        public async Task<string> GetHkrAbsenkAsync(string ain)
        {
            return await GetStringAsync("gethkrabsenk", ain);
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain"></param>
        /// <param name="value">Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 = 8.5 ° C...... 56&gt; = 28 ° C 254 = ON, 253 = OFF</param>
        /// <returns></returns>
        public void SetHkrtSoll(string ain, string value)
        {
            Get("sethkrtsoll", ain, value);
        }

        public async Task SetHkrtSollAsync(string ain, string value)
        {
            await GetAsync("sethkrtsoll", ain, value);
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public DeviceStats GetBasicDeviceStats(string ain)
        {
            return GetAs<DeviceStats>("getbasicdevicestats", ain);
        }

        public async Task<DeviceStats> GetBasicDeviceStatsAsync(string ain)
        {
            return await GetAsAsync<DeviceStats>("getbasicdevicestats", ain);
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public TemplateList GetTemplateListInfos(string ain)
        {
            return GetAs<TemplateList>("gettemplatelistinfos", ain);
        }

        public async Task<TemplateList> GetTemplateListInfosAsync(string ain)
        {
            return await GetAsAsync<TemplateList>("gettemplatelistinfos", ain);
        }

        /// <summary>
        /// Returns the basic information of all templates / templates. Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain"></param>
        /// <returns></returns>
        public void ApplyTemplate(string ain)
        {
            Get("applytemplate", ain);
        }

        public async Task<string> ApplyTemplateAsync(string ain)
        {
            return await GetStringAsync("applytemplate", ain);
        }

        /*
        setsimpleonoff

            setlevel
            setlevelpercentage 

            setcolor
            setcolortemperature
            getcolordefaults
            sethkrboost
            sethkrwindowopen
            setblind
            setname
            startulesubscription
            getsubscriptionstate

            getdeviceinfos
        */
        #endregion

        #region Public Async Methods




































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

        private void Get(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private void Get(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private void Get(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private async Task GetAsync(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private async Task GetAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private async Task GetAsync(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private string GetString(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private string GetString(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetStringAsync(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> GetStringAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private bool GetBool(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                string res = response.Content.ReadAsStringAsync().Result;
                return res == "1";
            }
        }

        private async Task<bool> GetBoolAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                return res == "1";
            }
        }

        private int GetInt(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                string res = response.Content.ReadAsStringAsync().Result;
                return int.Parse(res);
            }
        }

        private async Task<int> GetIntAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string res =  await response.Content.ReadAsStringAsync();
                return int.Parse(res);
            }
        }
        private T GetAs<T>(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                string res = response.Content.ReadAsStringAsync().Result;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T value = (T)serializer.Deserialize(new StringReader(res));
                return value;
            }
        }

        private T GetAs<T>(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                string res = response.Content.ReadAsStringAsync().Result;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T value = (T)serializer.Deserialize(new StringReader(res));
                return value;
            }
        }

        private async Task<T> GetAsAsync<T>(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T value = (T)serializer.Deserialize(new StringReader(res));
                return value;
            }
        }

        private async Task<T> GetAsAsync<T>(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T value = (T)serializer.Deserialize(new StringReader(res));
                return value;
            }
        }

        /*
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

        private string Get(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string Get(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private async Task<string> GetAsync(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&param={param}&sid={this.sessionId}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        */

        #endregion
    }
}
