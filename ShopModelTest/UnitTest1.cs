using DaycareModel.Entities;
using log4net;
using System;
using Unity;
using Xunit;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace DaycareModelTest
{
    public class UnitTest1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EventListener eventListener;

        public UnitTest1()
        {
            eventListener = new EventListener(log);
        }

        [Fact]
        public void Test1()
        {
            eventListener.Log(new PickupEvent() {
                TimeStamp = DateTime.Now
            });
            Assert.True(eventListener.Events.Count > 0);
        }
    }
}
