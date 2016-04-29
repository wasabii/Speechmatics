using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Speechmatics.Client
{

    [DataContract]
    public class JobPostResponse
    {

        /// <summary>
        /// Unique identifier of new job.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Available credit balance.
        /// </summary>
        [DataMember]
        [JsonProperty("balance")]
        public int Balance { get; set; }

        /// <summary>
        /// Amount of time to wait before checking for completion.
        /// </summary>
        [DataMember]
        [JsonProperty("check_wait")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan? CheckWait { get; set; }

        /// <summary>
        /// Credit charge for processing.
        /// </summary>
        [DataMember]
        [JsonProperty("cost")]
        public int Cost { get; set; }

    }

}
