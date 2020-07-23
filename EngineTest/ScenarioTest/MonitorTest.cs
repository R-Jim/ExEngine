using NUnit.Framework;
using System.Collections.Generic;
using ExtiliaEngine;

namespace EngineTest.ScenarioTest.MonitorTest
{
    class MonitorTest
    {
        Instance MonitorInstance;
        private string[] AddInstanceTypes;
        [SetUp]
        public void MonitorSetup()
        {
            AddInstanceTypes = new string[] { "MONITOR", "ADD", "INSTANCE" };
            MonitorInstance = new Instance("MONITOR", new string[] { "MONITOR" },
            new DynamicValueFactory("Value", new List<Instance>(), "Add"),
            new Trigger(new List<Condition> {
                new Condition("Types", "==", AddInstanceTypes)
            }, null)); ;
        }

        [Test]
        public void AddInstace()
        {
            List<Instance> instances = new Invoker(0, new Coordinate(0, 0)).Get();
            foreach (Instance instance in instances)
            {
                MonitorInstance.OnEffect(new Effect(AddInstanceTypes, null, instance));
            };
            Assert.AreEqual(instances.Count, ((List<Instance>)MonitorInstance.Value).Count);
        }
    }
}