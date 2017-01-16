using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Speechmatics.Client.Tests
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task TestMethod1()
        {
            var c = new SpeechmaticsApiClient("");
            var j = await c.GetJob(1820, 400754);
            var t = await c.GetTranscript(1820, 400754);
        }

    }

}
