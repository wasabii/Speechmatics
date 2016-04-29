using Newtonsoft.Json;

namespace Speechmatics.Client
{

    public class JobResponse
    {

        [JsonProperty("job")]
        public Job Job { get; set; }

    }

}
