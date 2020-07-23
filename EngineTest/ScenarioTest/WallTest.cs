using NUnit.Framework;
using System.Collections.Generic;
using ExtiliaEngine;

namespace EngineTest.ScenarioTest.WallTest
{
    class WallTest
    {
        Instance WallHpInstance;

        [SetUp]
        public void WallSetup()
        {
            Instance CoordinateInstance = new Instance(null, new string[] { "Wall", "Coordinate" },
                new DynamicValueFactory(null, new Coordinate(1, 1), null)
                , null);
            WallHpInstance = new Instance(null, new string[] { "Wall", "Hp" },
                new DynamicValueFactory("Value", 100.0, "+"),
                new Trigger(
                    new List<Condition>()
                    {
                    new ObjectCondition("Coordinate", "==",
                    CoordinateInstance, "Value"),
                    new Condition("Types", "in", "Hp")
                    }
                , null));
        }

        [Test]
        public void DamageWall()
        {
            Effect damageEffect = new Effect(
                new string[] { "Damage", "Hp" },
                new Coordinate(1, 1),
                -20.0
                );
            double initialValue = (double)WallHpInstance.Value;
            WallHpInstance.OnEffect(damageEffect);
            Assert.AreEqual(initialValue, (double)WallHpInstance.Value - (double)damageEffect.Value);
        }
    }
}