using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Speechmatics.Client
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobNotification
    {

        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "callback")]
        Callback,

    }

}
