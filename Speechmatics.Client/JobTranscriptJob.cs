using System;
using System.Globalization;
using System.Runtime.Serialization;


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Speechmatics.Client
{

    [DataContract]
    public class JobTranscriptJob
    {

        class CreatedAtDateTimeJsonConverter :
            DateTimeConverterBase
        {

            const string FORMAT_STRING = "ddd MMM %d HH:mm:ss yyyy";

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = serializer.Deserialize<string>(reader);
                if (value != null)
                    return DateTime.ParseExact(value, FORMAT_STRING, null, DateTimeStyles.AllowInnerWhite);
                else
                    return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value != null)
                    writer.WriteValue(((DateTime)value).ToString(FORMAT_STRING));
                else
                    writer.WriteNull();
            }

        }

        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("created_at")] // Fri Dec 18 08:39:12 2015
        [JsonConverter(typeof(CreatedAtDateTimeJsonConverter))]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [DataMember]
        [JsonProperty("duration")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan Duration { get; set; }
    }

}
