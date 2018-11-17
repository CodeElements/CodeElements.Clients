using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace YourRootNamespace.Clients
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    class JsonContent : StringContent
    {
        public static readonly JsonSerializerSettings JsonSettings = GetDefaultSettings();

        public JsonContent(object value) : this(value, null)
        {
        }

        public JsonContent(object value, Action<JsonSerializerSettings> settingsAction) : base(
            Serialize(value, settingsAction), Encoding.UTF8, "application/json")
        {
        }

        public static JsonSerializerSettings GetDefaultSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }

        private static string Serialize(object value, Action<JsonSerializerSettings> settingsAction)
        {
            JsonSerializerSettings settings;

            if (settingsAction == null)
            {
                settings = JsonSettings;
            }
            else
            {
                settings = GetDefaultSettings();
                settingsAction(settings);
            }

            return JsonConvert.SerializeObject(value, settings);
        }
    }
}