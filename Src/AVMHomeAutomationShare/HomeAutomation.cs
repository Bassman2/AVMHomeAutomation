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
        /// <summary>
        /// On value for heater.
        /// </summary>
        /// <remarks>Use for SetHkrtSoll</remarks>
        public const double On = double.MaxValue;

        /// <summary>
        /// Off value for heater
        /// </summary>
        /// <remarks>Use for SetHkrtSoll</remarks>
        public const double Off = double.MinValue;

        private readonly Uri defaultHost = new Uri("http://fritz.box");
        private readonly HttpClientHandler handler;
        private HttpClient client;
        private readonly string sessionId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="login">Login name.</param>
        /// <param name="password">Login password.</param>
        /// <param name="host">Host name.</param>
        public HomeAutomation(string login, string password, Uri host = null)
        {
            // connect
            this.handler = new HttpClientHandler
            {
                CookieContainer = new System.Net.CookieContainer(),
                UseCookies = true
            };
            this.client = new HttpClient(this.handler)
            {
                BaseAddress = host ?? this.defaultHost,
                Timeout = new TimeSpan(0, 2, 0)
            };

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
            return this.client.GetStringAsync(BuildUrl("getswitchlist")).Result.SplitList();
        }

        /// <summary>
        /// Returns the AIN / MAC list of all known sockets.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string[]> GetSwitchListAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchlist"))).SplitList();
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOn(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("setswitchon", ain)).Result.ToBool();
        }

        /// <summary>
        /// Turns on the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOnAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("setswitchon", ain))).ToBool();
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchOff(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("setswitchoff", ain)).Result.ToBool();
        }

        /// <summary>
        /// Switches off the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchOffAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("setswitchoff", ain))).ToBool();
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>New state of the socket</returns>
        public bool SetSwitchToggle(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("setswitchtoggle", ain)).Result.CheckStatusCode().ToBool();
        }

        /// <summary>
        /// Toggle the power socket on / off.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> SetSwitchToggleAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("setswitchtoggle", ain))).CheckStatusCode().ToBool();
        }


        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>State of the socket</returns>
        /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
        public bool? GetSwitchState(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getswitchstate", ain)).Result.ToNullableBool();
        }

        /// <summary>
        /// Determines the switching state of the socket.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
        public async Task<bool?> GetSwitchStateAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchstate", ain))).ToNullableBool();
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>True if connected; false if not</returns>
        public bool GetSwitchPresent(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getswitchpresent", ain)).Result.ToBool();
        }

        /// <summary>
        /// Determines the connection status of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<bool> GetSwitchPresentAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchpresent", ain))).ToBool();
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Power in W, null if unknown.</returns>
        public double? GetSwitchPower(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getswitchpower", ain)).Result.ToPower();
        }

        /// <summary>
        /// Determines current power taken from the power outlet.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double?> GetSwitchPowerAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchpower", ain))).ToPower();
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Energy in kWh, null if unknown.</returns>
        public double? GetSwitchEnergy(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getswitchenergy", ain)).Result.ToPower();
        }

        /// <summary>
        /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double?> GetSwitchEnergyAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchenergy", ain))).ToPower();
        }

        /// <summary>
        /// Returns identifiers of the actor.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>ColorName of the actor</returns>
        public string GetSwitchName(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getswitchname", ain)).Result.TrimEnd();
        }

        /// <summary>
        /// Returns identifiers of the actor.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<string> GetSwitchNameAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getswitchname", ain))).TrimEnd();
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>Information of all SmartHome devices</returns>
        public DeviceList GetDeviceListInfos()
        {
            return this.client.GetStringAsync(BuildUrl("getdevicelistinfos")).Result.XmlToAs<DeviceList>();
        }

        /// <summary>
        /// Provides the basic information of all SmartHome devices.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceList> GetDeviceListInfosAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("getdevicelistinfos"))).XmlToAs<DeviceList>();
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value in C.</returns>
        public double GetTemperature(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("gettemperature", ain)).Result.ToTemperature();
        }

        /// <summary>
        /// Last temperature information of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetTemperatureAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("gettemperature", ain))).ToTemperature();
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value °C, On or Off.</returns>
        public double GetHkrtSoll(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("gethkrtsoll", ain)).Result.ToHkrTemperature();
        }

        /// <summary>
        /// Setpoint temperature currently set for HKR.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrtSollAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("gethkrtsoll", ain))).ToHkrTemperature();
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>TTemperature value °C, On or Off.</returns>
        public double GetHkrKomfort(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("gethkrkomfort", ain)).Result.ToHkrTemperature();
        }

        /// <summary>
        /// Comfort temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrKomfortAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("gethkrkomfort", ain))).ToHkrTemperature();
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Temperature value °C, On or Off.</returns>
        public double GetHkrAbsenk(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("gethkrabsenk", ain)).Result.ToHkrTemperature();
        }

        /// <summary>
        /// Economy temperature set for HKR timer.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> GetHkrAbsenkAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("gethkrabsenk", ain))).ToHkrTemperature();
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Temperature value °C (8°C - 28°C), On or Off.</param>
        /// <returns>Temperature value °C, On or Off.</returns>
        public double SetHkrtSoll(string ain, double temperature)
        {
            if ((temperature < 8 || temperature > 28) && (temperature != On) && (temperature != Off))
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            return this.client.GetStringAsync(BuildUrl("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}")).Result.ToHkrTemperature(); 
        }

        /// <summary>
        /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Temperature value °C (8°C - 28°C), On or Off.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<double> SetHkrtSollAsync(string ain, double temperature)
        {
            if ((temperature < 8 || temperature > 28) && (temperature != On) && (temperature != Off))
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            return (await this.client.GetStringAsync(BuildUrl("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}"))).ToHkrTemperature();
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Device stats.</returns>
        public DeviceStats GetBasicDeviceStats(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getbasicdevicestats", ain)).Result.XmlToAs<DeviceStats>();
        }

        /// <summary>
        /// Provides the basic statistics (temperature, voltage, power) of the actuator.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DeviceStats> GetBasicDeviceStatsAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getbasicdevicestats", ain))).XmlToAs<DeviceStats>();
        }

        /// <summary>
        /// Provides the basics information of all routines/triggers.
        /// </summary>
        /// <returns>Trigger list.</returns>
        /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
        public TriggerList GetTriggerListInfos()
        {
            return this.client.GetStringAsync(BuildUrl("gettriggerlistinfos")).Result.XmlToAs<TriggerList>();
        }

        /// <summary>
        /// Provides the basics information of all routines/triggers.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
        public async Task<TriggerList> GetTriggerListInfosAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("gettriggerlistinfos"))).XmlToAs<TriggerList>();
        }

        /// <summary>
        /// Activate or deactivate trigger.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="active">True to activate, false to deactivate.</param>
        /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
        public void SetTriggerActive(string ain, bool active)
        {
            this.client.GetStringAsync(BuildUrl("settriggeractive", ain, $"active={(active ? "1" : "0")}")).Wait();
        }

        /// <summary>
        /// Activate or deactivate trigger.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="active">True to activate, false to deactivate.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
        public async Task SetTriggerActiveAsync(string ain, bool active)
        {
            await this.client.GetStringAsync(BuildUrl("settriggeractive", ain, $"active={(active ? "1" : "0")}"));
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <returns>Template list.</returns>
        public TemplateList GetTemplateListInfos()
        {
            return this.client.GetStringAsync(BuildUrl("gettemplatelistinfos")).Result.XmlToAs<TemplateList>();
        }

        /// <summary>
        /// Returns the basic information of all templates / templates.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<TemplateList> GetTemplateListInfosAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("gettemplatelistinfos"))).XmlToAs<TemplateList>();
        }

        /// <summary>
        /// Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        public void ApplyTemplate(string ain)
        {
            this.client.GetStringAsync(BuildUrl("applytemplate", ain)).Wait();
        }

        /// <summary>
        /// Apply template, the ain parameter is evaluated.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task ApplyTemplateAsync(string ain)
        {
            await this.client.GetStringAsync(BuildUrl("applytemplate", ain));
        }

        /// <summary>
        /// Device/actuator/lamp switch on/off or toggle.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff">Switch on, off or toggle.</param>
        public OnOff SetSimpleOnOff(string ain, OnOff onOff)
        {
            return this.client.GetStringAsync(BuildUrl("setsimpleonoff", ain, $"onoff={((int)onOff)}")).Result.ToOnOff();
        }

        /// <summary>
        /// Device/actuator/lamp switch on/off or toggle. 
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="onOff">Switch on, off or toggle.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<OnOff> SetSimpleOnOffAsync(string ain, OnOff onOff)
        {
            return (await this.client.GetStringAsync(BuildUrl("setsimpleonoff", ain, $"onoff={((int)onOff)}"))).ToOnOff();
        }

        /// <summary>
        /// Set dimming, height, brightness or level.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level (0 - 255) to set.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int SetLevel(string ain, int level)
        {
            if (level < 0 || level > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            return this.client.GetStringAsync(BuildUrl("setlevel", ain, $"level={level}")).Result.ToInt();
        }

        /// <summary>
        /// Set dimming, height, brightness or level.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level (0 - 255) to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<int> SetLevelAsync(string ain, int level)
        {
            if (level < 0 || level > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            return (await this.client.GetStringAsync(BuildUrl("setlevel", ain, $"level={level}"))).ToInt();
        }

        /// <summary>
        /// Set dimming, height, brightness or level level in percent.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level in percent (0 - 100) to set.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int SetLevelPercentage(string ain, int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            return this.client.GetStringAsync(BuildUrl("setlevelpercentage", ain, $"level={level}")).Result.ToInt();
        }

        /// <summary>
        /// Set dimming, height, brightness or level level in percent.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="level">Level in percent (0 - 100) to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<int> SetLevelPercentageAsync(string ain, int level)
        {
            if (level < 0 || level > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }
            return (await this.client.GetStringAsync(BuildUrl("setlevelpercentage", ain, $"level={level}"))).ToInt();
        }

        /// <summary>
        /// Adjust hue saturation color. The HSV color space is used with the hue saturation mode supports.
        /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue">Hue value of the color.</param>
        /// <param name="saturation">Saturation value of the color.</param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>Hue value of the color.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int SetColor(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }

            return this.client.GetStringAsync(BuildUrl("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}")).Result.ToInt();
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
        public async Task<int> SetColorAsync(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            return (await this.client.GetStringAsync(BuildUrl("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}"))).ToInt();
        }

        /// <summary>
        /// Adjust hue saturation color. 
        /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue">Hue value of the color.</param>
        /// <param name="saturation">Saturation value of the color.</param>
        /// <param name="duration">Speed of the change.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int SetUnmappedColor(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }

            return this.client.GetStringAsync(BuildUrl("setunmappedcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}")).Result.ToInt();
        }

        /// <summary>
        /// Adjust hue saturation color. 
        /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="hue">Hue value of the color.</param>
        /// <param name="saturation">Saturation value of the color.</param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<int> SetUnmappedColorAsync(string ain, int hue, int saturation, TimeSpan? duration = null)
        {
            if (hue < 0 || hue > 359)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }
            if (saturation < 0 || saturation > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }
            return (await this.client.GetStringAsync(BuildUrl("setunmappedcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}"))).ToInt();
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Color temperature in °Kelvin (2700° bis 6500°)</param>
        /// <param name="duration">Speed of the change.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int SetColorTemperature(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            return this.client.GetStringAsync(BuildUrl("setcolortemperature", ain, $"temperature={temperature}&&duration={duration.ToDeciseconds()}")).Result.ToInt();
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Color temperature in °Kelvin (2700° bis 6500°)</param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<int> SetColorTemperatureAsync(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            return (await this.client.GetStringAsync(BuildUrl("setcolortemperature", ain, $"temperature={temperature}&duration={duration.ToDeciseconds()}"))).ToInt();
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Color temperature in °Kelvin (2700° bis 6500°)</param>
        /// <param name="duration">Speed of the change.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetColorLevelTemperature(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            this.client.GetStringAsync(BuildUrl("addcolorleveltemplate", ain, $"temperature={temperature}&&duration={duration.ToDeciseconds()}")).Wait();
        }

        /// <summary>
        /// Adjust color temperature.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="temperature">Color temperature in °Kelvin (2700° bis 6500°)</param>
        /// <param name="duration">Speed of the change.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task SetColorLevelTemperatureAsync(string ain, int temperature, TimeSpan? duration = null)
        {
            if (temperature < 2700 || temperature > 6500)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature));
            }
            await this.client.GetStringAsync(BuildUrl("addcolorleveltemplate", ain, $"temperature={temperature}&duration={duration.ToDeciseconds()}"));
        }

        /// <summary>
        /// Provides a proposal for the color selection values.
        /// </summary>
        /// <returns>Color defaults class.</returns>
        public ColorDefaults GetColorDefaults()
        {
            return this.client.GetStringAsync(BuildUrl("getcolordefaults")).Result.XmlToAs<ColorDefaults>();
        }

        /// <summary>
        /// Provides a proposal for the color selection values.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<ColorDefaults> GetColorDefaultsAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("getcolordefaults"))).XmlToAs<ColorDefaults>();
        }

        /// <summary>
        /// Activate HKR Boost with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp">End time to set.</param>
        /// <returns>End time</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime? SetHkrBoost(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24,0,0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return this.client.GetStringAsync(BuildUrl("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}")).Result.ToNullableDateTime();
        }

        /// <summary>
        /// Activate HKR Boost with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp">End time to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<DateTime?> SetHkrBoostAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return (await this.client.GetStringAsync(BuildUrl("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"))).ToNullableDateTime();
        }

        /// <summary>
        /// HKR window open mode activate with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp">End time to set.</param>
        /// <returns>End time to set.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime? SetHkrWindowOpen(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return this.client.GetStringAsync(BuildUrl("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}")).Result.ToNullableDateTime();
        }

        /// <summary>
        /// HKR window open mode activate with end time for the disable: endtimestamp = null.
        /// The end time may not exceed to 24 hours in the future lie.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="endtimestamp">End time to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task<DateTime?> SetHkrWindowOpenAsync(string ain, DateTime? endtimestamp = null)
        {
            if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
            {
                throw new ArgumentOutOfRangeException(nameof(endtimestamp));
            }
            return (await this.client.GetStringAsync(BuildUrl("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"))).ToNullableDateTime();
        }

        /// <summary>
        /// Close, open or stop the blind.
        /// Blinds have the HANFUN unit type Blind (281).
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target">Target to set.</param>
        public void SetBlind(string ain, Target target)
        {
            this.client.GetStringAsync(BuildUrl("setblind", ain, $"target={target.ToString().ToLower()}")).Wait();
        }

        /// <summary>
        /// Close, open or stop the blind.
        /// Blinds have the HANFUN unit type Blind (281).
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="target">Target to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task SetBlindAsync(string ain, Target target)
        {
            await this.client.GetStringAsync(BuildUrl("setblind", ain, $"target={target.ToString().ToLower()}"));
        }

        /// <summary>
        /// Change device or group name.
        /// Attention: the user session must have the smart home and app right.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name">New name, maximum 40 characters.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public void SetName(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            this.client.GetStringAsync(BuildUrl("setname", ain, $"name={name}")).Wait();
        }



        /// <summary>
        /// Change device or group name.
        /// Attention: the user session must have the smart home and app right.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="name">New name, maximum 40 characters.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task SetNameAsync(string ain, string name)
        {
            if (name.Length > 40)
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }
            await this.client.GetStringAsync(BuildUrl("setname", ain, $"name={name}"));
        }

        /// <summary>
        /// json metadata of the template or change/set empty string
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="metaData">Metadata to set.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        public void SetMetaData(string ain, MetaData metaData)
        {
            
            this.client.GetStringAsync(BuildUrl("setmetadata", ain, $"metadata={metaData.AsToJson()}")).Wait();
        }

        /// <summary>
        /// json metadata of the template or change/set empty string
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <param name="metaData">Metadata to set.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        public async Task SetMetaDataAsync(string ain, MetaData metaData)
        {
            
            await this.client.GetStringAsync(BuildUrl("setmetadata", ain, $"metadata={metaData.AsToJson()}"));
        }

        /// <summary>
        /// Start DECT ULE device registration.
        /// </summary>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public void StartUleSubscription()
        {
            this.client.GetStringAsync(BuildUrl("startulesubscription")).Wait();
        }

        /// <summary>
        /// Start DECT ULE device registration.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task StartUleSubscriptionAsync()
        {
            await this.client.GetStringAsync(BuildUrl("startulesubscription"));
        }

        /// <summary>
        /// Query DECT-ULE device registration status.
        /// </summary>
        /// <returns>Return the subscription state</returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public SubscriptionState GetSubscriptionState()
        {
            return this.client.GetStringAsync(BuildUrl("getsubscriptionstate")).Result.XmlToAs<SubscriptionState>();
        }

        /// <summary>
        /// Query DECT-ULE device registration status.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
        public async Task<SubscriptionState> GetSubscriptionStateAsync()
        {
            return (await this.client.GetStringAsync(BuildUrl("getsubscriptionstate"))).XmlToAs<SubscriptionState>();
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>Information of one SmartHome devices</returns>
        public Device GetDeviceInfos(string ain)
        {
            return this.client.GetStringAsync(BuildUrl("getdeviceinfos", ain)).Result.XmlToAs<Device>();
        }

        /// <summary>
        /// Provides the basic information of one SmartHome devices.
        /// </summary>
        /// <param name="ain">Identification of the actor or template.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<Device> GetDeviceInfosAsync(string ain)
        {
            return (await this.client.GetStringAsync(BuildUrl("getdeviceinfos", ain))).XmlToAs<Device>();
        }

        /// <summary>
        /// Create a bug report file.
        /// </summary>
        public void CreateBugReportFile()
        {
//            string fileName = $"BugReport-{DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss")}.xml";
            string fileName = $"BugReport-{DateTime.Now:yyy-MM-dd-HH-mm-ss}.xml";
            using (var file = File.CreateText(fileName))
            {
                file.WriteLine("<Report>");
                file.WriteLine(this.client.GetStringAsync(BuildUrl("getdevicelistinfos")).Result);
                file.WriteLine(this.client.GetStringAsync(BuildUrl("gettemplatelistinfos")).Result);
                file.WriteLine(this.client.GetStringAsync(BuildUrl("getcolordefaults")).Result);
                try
                {
                    file.WriteLine(this.client.GetStringAsync(BuildUrl("gettriggerlistinfos")).Result);
                }
                catch
                { }
                file.WriteLine("</Report>");
            }
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

        private string BuildUrl(string cmd)
        {
            return $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
        }

        private string BuildUrl(string cmd, string ain)
        {
            return $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
        }

        private string BuildUrl(string cmd, string ain, string param)
        {
            return $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
        }

        //private async Task<string> GetStringAsync(string p)
        //{
        //    using (HttpResponseMessage response = await this.client.GetAsync(p))  // .ConfigureAwait(false)
        //    {
        //        response.EnsureSuccessStatusCode();
        //        string str = await response.Content.ReadAsStringAsync();
        //        return str;
        //    }
        //}

        #endregion
    }
}
