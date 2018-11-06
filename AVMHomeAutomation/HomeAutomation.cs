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

        public string[] GetSwitchList()
        {
            string list = Get("getswitchlist");
            return list.TrimEnd().Split(',');
        }

        public bool SetSwitchOn(string ain)
        {
            string res = Get(ain, "setswitchon");
            return res == "1";
        }

        public bool SetSwitchOff(string ain)
        {
            string res = Get(ain, "setswitchoff");
            return res == "1";
        }
        public bool SetsSwitchToggle(string ain)
        {
            string res = Get(ain, "setswitchtoggle");
            return res == "1";
        }

        public bool GetSwitchState(string ain)
        {
            string res = Get(ain, "getswitchstate");
            return res == "1";
        }

        public bool GetSwitchPresent(string ain)
        {
            string res = Get(ain, "getswitchpresent");
            return res == "1";
        }

        public int GetSwitchPower(string ain)
        {
            string res = Get(ain, "getswitchpower");
            return int.Parse(res);
        }

        public int GetSwitchEnergy(string ain)
        {
            string res = Get(ain, "getswitchenergy");
            return int.Parse(res);
        }

        public string GetSwitchName(string ain)
        {
            return Get(ain, "getswitchname");
        }

        public DeviceList GetDeviceListInfos()
        {
            string res = Get("getdevicelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));
            var value = (DeviceList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public string GetTemperature(string ain)
        {
            return Get(ain, "gettemperature");
        }

        public string GetHkrtSoll(string ain)
        {
            return Get(ain, "gethkrtsoll");
        }

        public string GetHkrKomfort(string ain)
        {
            return Get(ain, "gethkrkomfort");
        }

        public string GetHkrAbsenk(string ain)
        {
            return Get(ain, "gethkrabsenk");
        }

        public string SetHkrtSoll(string ain, string value)
        {
            return Get(ain, "sethkrtsoll", value);
        }

        public DeviceStats GetBasicDeviceStats(string ain)
        {
            string res = Get(ain, "getbasicdevicestats");
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceStats));
            var value = (DeviceStats)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public TemplateList GetTemplateListInfos(string ain)
        {
            string res = Get(ain, "gettemplatelistinfos");
            XmlSerializer serializer = new XmlSerializer(typeof(TemplateList));
            var value = (TemplateList)serializer.Deserialize(new StringReader(res));
            return value;
        }

        public string ApplyTemplate(string ain)
        {
            return Get(ain, "applytemplate");
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
