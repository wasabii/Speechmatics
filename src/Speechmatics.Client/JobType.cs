using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Speechmatics.Client
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobType
    {

        [EnumMember(Value = "transcription")]
        Transcription,

    }

}
