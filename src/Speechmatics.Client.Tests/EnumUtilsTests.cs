
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Speechmatics.Client.Util;

namespace Speechmatics.Client.Tests
{

    [TestClass]
    public class EnumUtilsTests
    {

        [TestMethod]
        public void Test_ToEnumString()
        {
            var e = JobNotification.Callback;
            Assert.AreEqual("callback", e.ToEnumString());
        }

        [TestMethod]
        public void Test_ToEnumStringNullable()
        {
            var e = (JobNotification?)JobNotification.Callback;
            Assert.AreEqual("callback", e.ToEnumString());
        }

        [TestMethod]
        public void Test_ToEnum()
        {
            var e = EnumUtil.ToEnum<JobNotification>("callback");
            Assert.AreEqual(JobNotification.Callback, e);
        }

    }

}
