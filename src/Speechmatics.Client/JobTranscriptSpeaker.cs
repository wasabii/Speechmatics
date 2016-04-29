using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Speechmatics.Client
{

    [DataContract]
    public class JobTranscriptSpeaker
    {

        [DataMember]
        [JsonProperty("duration")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan Duration { get; set; }

        [DataMember]
        [JsonProperty("confidence")]
        public float? Confidence { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan Time { get; set; }

    }

}
