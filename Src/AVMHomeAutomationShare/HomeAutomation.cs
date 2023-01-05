using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace AVMHomeAutomation
{
    /// <summary>
    /// AVM Home Automation service class.
    /// </summary>
    public class HomeAutomation : IDisposable
    {
        public const double On = double.MaxValue;
        public const double Off = double.MinValue;

        private Uri host = new Uri("http://fritz.box");
        private HttpClientHandler handler;
        private HttpClient client;
        private string sessionId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="login">Login name.</param>
        /// <param name="password">Login password.</param>
        public HomeAutomation(string login, string password)
        {
            // connect
            this.handler = new HttpClientHandler();
            this.handler.CookieContainer = new System.Net.CookieContainer();
            this.handler.UseCookies = true;
            this.client = new HttpClient(this.handler);
            this.client.BaseAddress = host;

            // get session id
            this.sessionId = GetSessionId(login, password);
        }

        /// <summary>
        /// Dispose the service.
        /// </summary>
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
            return GetString("getswitchlist").SplitList();
        }

        /// <summary>
        /// Returns the AIN / MAC list of all known sockets.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string[]> GetSwitchListAsync()
        {
            return (await GetStringAsync("getswitchlist")).SplitList();
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOn(string ain)
        {
            return GetString("setswitchon", ain).ToBool();
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOnAsync(string ain)
        {
            return (await GetStringAsync("setswitchon", ain)).ToBool();
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOff(string ain)
        {
            return GetString("setswitchoff", ain).ToBool();
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOffAsync(string ain)
        {
            return (await GetStringAsync("setswitchoff", ain)).ToBool();
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchToggle(string ain)
        {
            return GetString("setswitchtoggle", ain).ToBool();
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchToggleAsync(string ain)
        {
            return (await GetStringAsync("setswitchtoggle", ain)).ToBool();
        }


        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>State of the socket</returns>
        /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
        public bool? GetSwitchState(string ain)
        {
            return GetString("getswitchstate", ain).ToNullableBool();
        }

        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
        public async Task<bool?> GetSwitchStateAsync(string ain)
        {
            return (await GetStringAsync("getswitchstate", ain)).ToNullableBool();
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>True if connected; false if not</returns>
        public bool GetSwitchPresent(string ain)
        {
            return GetString("getswitchpresent", ain).ToBool();
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> GetSwitchPresentAsync(string ain)
        {
            return (await GetStringAsync("getswitchpresent", ain)).ToBool();
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Power in mW, null if unknown.</returns>
        public int? GetSwitchPower(string ain)
        {
            return GetString("getswitchpower", ain).ToPower();
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<int?> GetSwitchPowerAsync(string ain)
        {
            return (await GetStringAsync("getswitchpower", ain)).ToPower();
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Energy in Wh, null if unknown.</returns>
        public int? GetSwitchEnergy(string ain)
        {
            return GetString("getswitchenergy", ain).ToPower();
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<int?> GetSwitchEnergyAsync(string ain)
        {
            return (await GetStringAsync("getswitchenergy", ain)).ToPower();
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
        /// Returns identifiers of the actor.
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
            return GetString("getdevicelistinfos").ToAs<DeviceList>();
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceList> GetDeviceListInfosAsync()
        {
            return (await GetStringAsync("getdevicelistinfos")).ToAs<DeviceList>();
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in C.</returns>
        public double GetTemperature(string ain)
        {
            return GetString("gettemperature", ain).ToTemperature();
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetTemperatureAsync(string ain)
        {
            return (await GetStringAsync("gettemperature", ain)).ToTemperature();
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value °C, On or Off.</returns>
        public double GetHkrtSoll(string ain)
        {
            return GetString("gethkrtsoll", ain).ToHkrTemperature();
            
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrtSollAsync(string ain)
        {
            return (await GetStringAsync("gethkrtsoll", ain)).ToHkrTemperature();
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>TTemperature value °C, On or Off.</returns>
        public double GetHkrKomfort(string ain)
        {
            return GetString("gethkrkomfort", ain).ToHkrTemperature();
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrKomfortAsync(string ain)
        {
            return (await GetStringAsync("gethkrkomfort", ain)).ToHkrTemperature();
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value °C, On or Off.</returns>
        public double GetHkrAbsenk(string ain)
        {
            return GetString("gethkrabsenk", ain).ToHkrTemperature();
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrAbsenkAsync(string ain)
        {
            return (await GetStringAsync("gethkrabsenk", ain)).ToHkrTemperature();
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Temperature value °C, On or Off.</param>
        /// <returns></returns>
        public void SetHkrtSoll(string ain, double temperature)
        {
            Get("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}");
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Temperature value °C, On or Off.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetHkrtSollAsync(string ain, double temperature)
        {
            await GetAsync("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}");
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns></returns>
        public DeviceStats GetBasicDeviceStats(string ain)
        {
            return GetString("getbasicdevicestats", ain).ToAs<DeviceStats>();
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceStats> GetBasicDeviceStatsAsync(string ain)
        {
            return (await GetStringAsync("getbasicdevicestats", ain)).ToAs<DeviceStats>();
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <returns></returns>
        public TemplateList GetTemplateListInfos()
        {
            return GetString("gettemplatelistinfos").ToAs<TemplateList>();
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<TemplateList> GetTemplateListInfosAsync()
        {
            return (await GetStringAsync("gettemplatelistinfos")).ToAs<TemplateList>();
        }

        /// <summary>
        /// Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        public void ApplyTemplate(string ain)
        {
            Get("applytemplate", ain);
        }

        /// <summary>
        /// Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task ApplyTemplateAsync(string ain)
        {
            await GetAsync("applytemplate", ain);
        }

        /// <summary>
        /// Device/actuator/lamp switch on/off or toggle.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff">Switch on, off or toggle.</param>
        public void SetSimpleOnOff(string ain, OnOff onOff)
        {
            Get("setsimpleonoff", ain, $"onoff={((int)onOff)}");
        }

        /// <summary>
        /// Device/actuator/lamp switch on/off or toggle. 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff">Switch on, off or toggle.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetSimpleOnOffAsync(string ain, OnOff onOff)
        {
            await GetAsync("setsimpleonoff", ain, $"onoff={((int)onOff)}");
        }

        /// <summary>
        /// Set dimming, height, brightness or level.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level (0 - 255) to set.</param>
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
        /// Set dimming, height, brightness or level.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level (0 - 255) to set.</param>
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
        /// Set dimming, height, brightness or level level in percent.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level in percent (0 - 100) to set.</param>
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
        /// Set dimming, height, brightness or level level in percent.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level in percent (0 - 100) to set.</param>
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
        /// Adjust hue saturation color. The HSV color space is used with the hue saturation mode supports.
        /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue">Hue value of the color.</param>
        /// <param name="saturation">Saturation value of the color.</param>
        /// <param name="duration">Speed of the change.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetColor(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            
            Get("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}");
        }

        /// <summary>
        /// Adjust hue saturation color. The HSV color space is used with the hue saturation mode supports.
        /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue">Hue value of the color.</param>
        /// <param name="saturation">Saturation value of the color.</param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetColorAsync(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            await GetAsync("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}");
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature"></param>
        /// <param name="duration">Speed of the change.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetColorTemperature(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            Get("setcolortemperature", ain, $"temperature={temperature}&&duration={duration.ToDeciseconds()}");
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature"></param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetColorTemperatureAsync(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            await GetAsync("setcolortemperature", ain, $"temperature={temperature}&duration={duration.ToDeciseconds()}");
        }

        /// <summary>
        /// Provides a proposal for the color selection values.
        /// </summary>
        /// <returns></returns>
        public ColorDefaults GetColorDefaults()
        {
            return GetString("getcolordefaults").ToAs<ColorDefaults>();
        }

        /// <summary>
        /// Provides a proposal for the color selection values.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<ColorDefaults> GetColorDefaultsAsync()
        {
            return (await GetStringAsync("getcolordefaults")).ToAs<ColorDefaults>();
        }

        /// <summary>
        /// Activate HKR Boost with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime? SetHkrBoost(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24,0,0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return GetString("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}").ToNullableDateTime();
        }

        /// <summary>
        /// Activate HKR Boost with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<DateTime?> SetHkrBoostAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return (await GetStringAsync("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}")).ToNullableDateTime();
        }

        /// <summary>
        /// HKR window open mode activate with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime? SetHkrWindowOpen(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return GetString("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}").ToNullableDateTime();
        }

        /// <summary>
        /// HKR window open mode activate with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<DateTime?> SetHkrWindowOpenAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return (await GetStringAsync("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}")).ToNullableDateTime();
        }

        /// <summary>
        /// Close, open or stop the blind.
        /// Blinds have the HANFUN unit type Blind (281).
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target"></param>
        public void SetBlind(string ain, Target target)
        {
            Get("setblind", ain, $"target={target.ToString().ToLower()}");
        }

        /// <summary>
        /// Close, open or stop the blind.
        /// Blinds have the HANFUN unit type Blind (281).
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetBlindAsync(string ain, Target target)
        {
            await GetAsync("setblind", ain, $"target={target.ToString().ToLower()}");
        }

        /// <summary>
        /// Change device or group name.
        /// Attention: the user session must have the smart home and app right.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public void SetName(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            Get("setname", ain, $"name={name}");
        }

        /// <summary>
        /// Change device or group name.
        /// Attention: the user session must have the smart home and app right.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name"></param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task SetNameAsync(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            await GetAsync("setname", ain, $"name={name}");
        }

        /// <summary>
        /// Start DECT ULE device registration.
        /// </summary>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public void StartUleSubscription()
        {
            Get("startulesubscription");
        }

        /// <summary>
        /// Start DECT ULE device registration.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task StartUleSubscriptionAsync()
        {
            await GetAsync("startulesubscription");
        }

        /// <summary>
        /// Query DECT-ULE device registration status.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public State GetSubscriptionState()
        {
            return GetString("getsubscriptionstate").ToAs<State>();
        }

        /// <summary>
        /// Query DECT-ULE device registration status.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task<State> GetSubscriptionStateAsync()
        {
            return (await GetStringAsync("getsubscriptionstate")).ToAs<State>();
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Information of one SmartHome devices</returns>
        public Device GetDeviceInfos(string ain)
        {
            return GetString("getdeviceinfos", ain).ToAs<Device>();
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<Device> GetDeviceInfosAsync(string ain)
        {
            return (await GetStringAsync("getdeviceinfos", ain)).ToAs<Device>();
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

        private string GetMD5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));
            return data.Select(d => d.ToString("x2")).Aggregate((a, b) => a + b);
        }

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

        private string GetString(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
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

        private async Task<string> GetStringAsync(string cmd, string ain, string param)
        {
            string request = $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
            return await RequestAsync(request);
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
