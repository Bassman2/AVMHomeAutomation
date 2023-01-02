using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
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
            if (this.client != null)
            {
                this.client.Dispose();
                this.client = null;
            }            
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string[]> GetSwitchListAsync()
        {
            string list = await GetStringAsync("getswitchlist");
            return list.TrimEnd().Split(',');
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOn(string ain)
        {
            return GetBool("setswitchon", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOnAsync(string ain)
        {
            return await GetBoolAsync("setswitchon", ain);
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOff(string ain)
        {
            return GetBool("setswitchoff", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOffAsync(string ain)
        {
            return await GetBoolAsync("setswitchoff", ain);
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchToggle(string ain)
        {
            return GetBool("setswitchtoggle", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchToggleAsync(string ain)
        {
            return await GetBoolAsync("setswitchtoggle", ain);
        }


        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>State of the socket</returns>
        public bool GetSwitchState(string ain)
        {
            return GetBool("getswitchstate", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> GetSwitchStateAsync(string ain)
        {
            return await GetBoolAsync("getswitchstate", ain);
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>True if connected; false if not</returns>
        public bool GetSwitchPresent(string ain)
        {
            return GetBool("getswitchpresent", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> GetSwitchPresentAsync(string ain)
        {
            return await GetBoolAsync("getswitchpresent", ain);
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Power in mW, "inval" if unknown.</returns>
        public int GetSwitchPower(string ain)
        {
            return GetInt("getswitchpower", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<int> GetSwitchPowerAsync(string ain)
        {
            return await GetIntAsync("getswitchpower", ain);
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Energy in Wh, "inval" if unknown.</returns>
        public int GetSwitchEnergy(string ain)
        {
            return GetInt("getswitchenergy", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<int> GetSwitchEnergyAsync(string ain)
        {
            return await GetIntAsync("getswitchenergy", ain);
        }

        /// <summary>
        /// Returns identifiers of the actor.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Name of the actor</returns>
        public string GetSwitchName(string ain)
        {
            return GetString("getswitchname", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetSwitchNameAsync(string ain)
        {
            return await GetStringAsync("getswitchname", ain);
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>Information of all SmartHome devices</returns>
        public DeviceList GetDeviceListInfos()
        {
            return GetAs<DeviceList>("getdevicelistinfos");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceList> GetDeviceListInfosAsync()
        {
            return await GetAsAsync<DeviceList>("getdevicelistinfos");
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in C.</returns>
        public double GetTemperature(string ain)
        {
            // Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C
            return GetInt("gettemperature", ain) / 10.0;
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetTemperatureAsync(string ain)
        {
            // Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C
            int temperature = await GetIntAsync("gettemperature", ain);
            return temperature / 10.0;
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrtSoll(string ain)
        {
            return GetInt("gethkrtsoll", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetHkrtSollAsync(string ain)
        {
            return await GetStringAsync("gethkrtsoll", ain);
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrKomfort(string ain)
        {
            return GetInt("gethkrkomfort", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetHkrKomfortAsync(string ain)
        {
            return await GetStringAsync("gethkrkomfort", ain);
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.</returns>
        public int GetHkrAbsenk(string ain)
        {
            return GetInt("gethkrabsenk", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetHkrAbsenkAsync(string ain)
        {
            return await GetStringAsync("gethkrabsenk", ain);
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="value">Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 = 8.5 ° C...... 56&gt; = 28 ° C 254 = ON, 253 = OFF</param>
        /// <returns></returns>
        public void SetHkrtSoll(string ain, string value)
        {
            Get("sethkrtsoll", ain, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="value"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetHkrtSollAsync(string ain, string value)
        {
            await GetAsync("sethkrtsoll", ain, value);
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns></returns>
        public DeviceStats GetBasicDeviceStats(string ain)
        {
            return GetAs<DeviceStats>("getbasicdevicestats", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceStats> GetBasicDeviceStatsAsync(string ain)
        {
            return await GetAsAsync<DeviceStats>("getbasicdevicestats", ain);
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns></returns>
        public TemplateList GetTemplateListInfos(string ain)
        {
            return GetAs<TemplateList>("gettemplatelistinfos", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<TemplateList> GetTemplateListInfosAsync(string ain)
        {
            return await GetAsAsync<TemplateList>("gettemplatelistinfos", ain);
        }

        /// <summary>
        /// Returns the basic information of all templates / templates. Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        public void ApplyTemplate(string ain)
        {
            Get("applytemplate", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task ApplyTemplateAsync(string ain)
        {
            await GetAsync("applytemplate", ain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff"></param>
        public void SetSimpleOnOff(string ain, OnOff onOff)
        {
            Get("setsimpleonoff", ain, $"onoff={((int)onOff)}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetSimpleOnOffAsync(string ain, OnOff onOff)
        {
            await GetAsync("setsimpleonoff", ain, $"onoff={((int)onOff)}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetLevel(string ain, int level)
        {
            if (level < 0 || level > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            Get("setlevel", ain, $"level={level}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetLevelAsync(string ain, int level)
        {
            if (level < 0 || level > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            await GetAsync("setlevel", ain, $"level={level}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetLevelPercentage(string ain, int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            Get("setlevelpercentage", ain, $"level={level}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetLevelPercentageAsync(string ain, int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            await GetAsync("setlevelpercentage", ain, $"level={level}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="duration"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetColor(string ain, int hue, int saturation, int duration)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            if (duration < 0 || duration > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
            Get("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="duration"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetColorAsync(string ain, int hue, int saturation, int duration)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            if (duration < 0 || duration > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
            await GetAsync("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature"></param>
        /// <param name="duration"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetColortemperature(string ain, int temperature, int duration)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            if (duration < 0 || duration > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
            Get("setcolortemperature", ain, $"temperature={temperature}&&duration={duration}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature"></param>
        /// <param name="duration"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetColortemperatureAsync(string ain, int temperature, int duration)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            if (duration < 0 || duration > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
            await GetAsync("setcolortemperature", ain, $"temperature={temperature}&duration={duration}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ColorDefaults GetColorDefaults()
        {
            return GetAs<ColorDefaults>("getcolordefaults");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<ColorDefaults> GetColorDefaultsAsync()
        {
            return await GetAsAsync<ColorDefaults>("getcolordefaults");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetHkrBoost(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24,0,0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            Get("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetHkrBoostAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            await GetAsync("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetHkrWindowOpen(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            Get("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetHkrWindowOpenAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            await GetAsync("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target"></param>
        public void SetBlind(string ain, Target target)
        {
            Get("setblind", ain, $"target={target.ToString().ToLower()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetBlindAsync(string ain, Target target)
        {
            await GetAsync("setblind", ain, $"target={target.ToString().ToLower()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetName(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            Get("setname", ain, $"name={name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetNameAsync(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            await GetAsync("setname", ain, $"name={name}");
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartUleSubscription()
        {
            Get("startulesubscription");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task StartUleSubscriptionAsync()
        {
            await GetAsync("startulesubscription");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public State GetSubscriptionState()
        {
            return GetAs<State>("getsubscriptionstate");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<State> GetSubscriptionStateAsync()
        {
            return await GetAsAsync<State>("getsubscriptionstate");
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Information of one SmartHome devices</returns>
        public Device GetDeviceInfos(string ain)
        {
            return GetAs<Device>("getdeviceinfos", ain);
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<Device> GetDeviceInfosAsync(string ain)
        {
            return await GetAsAsync<Device>("getdeviceinfos", ain);
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

        //private async Task<string> GetSessionIdAsync(string login, string password)
        //{
        //    string sessionId;
        //    string challenge;

        //    using (HttpResponseMessage response = await this.client.GetAsync("login_sid.lua"))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        Stream stream = await response.Content.ReadAsStreamAsync();
        //        XDocument doc = XDocument.Load(stream);
        //        XElement info = doc.FirstNode as XElement;
        //        sessionId = info.Element("SID").Value;
        //        challenge = info.Element("Challenge").Value;
        //    }

        //    if (sessionId == "0000000000000000")
        //    {
        //        string resp = $"{challenge}-{GetMD5Hash(challenge + "-" + password)}";
        //        string request = $"login_sid.lua?username={login}&response={resp}";
        //        using (HttpResponseMessage response = await this.client.GetAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            Stream stream = await response.Content.ReadAsStreamAsync();
        //            XDocument doc = XDocument.Load(stream);
        //            XElement info = doc.FirstNode as XElement;
        //            sessionId = info.Element("SID").Value;
        //        }
        //    }
        //    return sessionId;
        //}

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
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
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
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private string GetString(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            return Request(request);
        }

        private string GetString(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            return Request(request);
        }

        private async Task<string> GetStringAsync(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            return await RequestAsync(request);
        }

        private async Task<string> GetStringAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            return await RequestAsync(request);
        }

        private bool GetBool(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = Request(request);
            return res == "1";
        }

        private async Task<bool> GetBoolAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = await RequestAsync(request);
            return res == "1";
        }

        private int GetInt(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = Request(request);
            return int.Parse(res);
        }

        private async Task<int> GetIntAsync(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = await RequestAsync(request);
            return int.Parse(res);
        }

        private T GetAs<T>(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            string res = Request(request);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value = (T)serializer.Deserialize(new StringReader(res));
            return value;
        }

        private T GetAs<T>(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = Request(request);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value = (T)serializer.Deserialize(new StringReader(res));
            return value;
        }

        private async Task<T> GetAsAsync<T>(string cmd)
        {
            string request = $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
            string res = await RequestAsync(request);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value = (T)serializer.Deserialize(new StringReader(res));
            return value;
        }

        private async Task<T> GetAsAsync<T>(string cmd, string ain)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
            string res = await RequestAsync(request);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value = (T)serializer.Deserialize(new StringReader(res));
            return value;
        }

        private string Request(string request)
        {
            using (HttpResponseMessage response = this.client.GetAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result.TrimEnd();
            }
        }

        private async Task<string> RequestAsync(string request)
        {
            using (HttpResponseMessage response = await this.client.GetAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                return res.TrimEnd();
            }
        }

        #endregion
    }
}
