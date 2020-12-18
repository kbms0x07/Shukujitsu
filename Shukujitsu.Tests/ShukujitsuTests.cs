using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Shukujitsu.Tests
{
    [TestClass]
    public class ShukujitsuTests
    {
        [TestMethod]
        [DataRow("2020/2/23", true, DisplayName = "天皇誕生日")]
        [DataRow("2020/12/17", false, DisplayName = "平日")]
        [DataRow("2021/1/1", true, DisplayName = "元日")]
        public void IsShukujitsuTest(string dateStr, bool excpect)
        {
            Assert.AreEqual(excpect, DateTime.Parse(dateStr).IsShukujitsu());
        }
    }
}