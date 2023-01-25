using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Newtonsoft.Json;

namespace AutomationFramework
{
    public  class NewtonsoftJsonSerializer : ISerializer,IDeserializer
    {
        private readonly JsonSerializer _serializer;
        private string ContentType { get; set; }
        private string DateFormat { get; set; }
        private string RootElement { get; set; }

        public static NewtonsoftJsonSerializer Default => new NewtonsoftJsonSerializer(new JsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        });

        string ISerializer.ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NewtonsoftJsonSerializer(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using StringWriter stringWriter = new StringWriter();
            using JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter);
            _serializer.Serialize(jsonWriter, obj);
            return stringWriter.ToString();
        }

        public T Deserialize<T>(IRestResponse response)
        {
            using StringReader reader = new StringReader(response.Content);
            using JsonTextReader jsonTextReader = new JsonTextReader(reader);
            return _serializer.Deserialize<T>(jsonTextReader);
        }

        
    }
}
