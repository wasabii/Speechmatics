using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Speechmatics.Client
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobStatus
    {

        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "transcribing")]
        Transcribing,

        [EnumMember(Value = "rejected")]
        Rejected,

        [EnumMember(Value = "done")]
        Done,

    }

}
