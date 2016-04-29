using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Speechmatics.Client
{

    [DataContract]
    public class Job
    {

        /// <summary>
        /// Unique identifier of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Amount of time to delay before checking for job status.
        /// </summary>
        [DataMember]
        [JsonProperty("check_wait")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan? CheckWait { get; set; }

        /// <summary>
        /// Time at which the job was created.
        /// </summary>
        [DataMember]
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Duration of the audio of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("duration")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Current status of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("job_status")]
        public JobStatus Status { get; set; }

        /// <summary>
        /// Type of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("job_type")]
        public JobType Type { get; set; }

        /// <summary>
        /// Language of the audio of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// Metadata associated with the job.
        /// </summary>
        [DataMember]
        [JsonProperty("meta")]
        public string Meta { get; set; }

        /// <summary>
        /// Name of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The recommended time for your next progress check in epoch seconds.
        /// </summary>
        [DataMember]
        [JsonProperty("next_check")]
        [Obsolete("Please use CheckWait instead.")]
        [JsonConverter(typeof(TimeSpanFromSecondsJsonConverter))]
        public TimeSpan NextCheck { get; set; }

        /// <summary>
        /// Method of notification of the job.
        /// </summary>
        [DataMember]
        [JsonProperty("notification")]
        public JobNotification Notification { get; set; }

        /// <summary>
        /// Name of the processed transcription file.
        /// </summary>
        [DataMember]
        [JsonProperty("transcription")]
        public string Transcription { get; set; }

        /// <summary>
        /// Internal url used to locate your file on the Speechmatics system
        /// </summary>
        [DataMember]
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// User ID of the user that owns the job.
        /// </summary>
        [DataMember]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

    }

}
