using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Speechmatics.Client
{
    
    [DataContract]
    public class JobTranscript
    {

        [DataMember]
        [JsonProperty("job")]
        public JobTranscriptJob Job { get; set; }

        [DataMember]
        [JsonProperty("speakers")]
        public JobTranscriptSpeaker[] Speakers { get; set; }

        [DataMember]
        [JsonProperty("words")]
        public JobTranscriptWord[] Words { get; set; }

        [DataMember]
        [JsonProperty("format")]
        public string Format { get; set; }

    }

}
