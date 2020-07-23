using NUnit.Framework;
using ExtiliaEngine;
namespace EngineTest.TriggerTest.ConditionTest
{
    class EffectDoubleValueTest
    {
        public Effect EffectWithDoubleValue;

        [SetUp]
        public void Setup()
        {
            EffectWithDoubleValue = new Effect(null, null, 10.0);
        }

        [Test]
        public void EqualTest()
        {
            Condition condition = new Condition("Value", "==", EffectWithDoubleValue.Value);
            Assert.IsTrue(condition.IsMatchCondition(EffectWithDoubleValue));
        }

        [Test]
        public void NotEqualTest()
        {
            Condition condition = new Condition("Value", "!=", 0);
            Assert.IsTrue(condition.IsMatchCondition(EffectWithDoubleValue));
        }

        [Test]
        public void LargerTest()
        {
            Condition condition = new Condition("Value", ">", (double)EffectWithDoubleValue.Value + 5.0);
            Assert.IsTrue(condition.IsMatchCondition(EffectWithDoubleValue));
        }

        [Test]
        public void LargerOrEqualTest()
        {
            Condition largerCondition = new Condition("Value", ">=", (double)EffectWithDoubleValue.Value + 5.0);
            Assert.IsTrue(largerCondition.IsMatchCondition(EffectWithDoubleValue));
            Condition equallCondition = new Condition("Value", ">=", (double)EffectWithDoubleValue.Value);
            Assert.IsTrue(equallCondition.IsMatchCondition(EffectWithDoubleValue));
        }

        [Test]
        public void SmallerTest()
        {
            Condition condition = new Condition("Value", "<", (double)EffectWithDoubleValue.Value - 5.0);
            Assert.IsTrue(condition.IsMatchCondition(EffectWithDoubleValue));
        }

        [Test]
        public void SmallerOrEqualTest()
        {
            Condition smallerCondition = new Condition("Value", "<=", (double)EffectWithDoubleValue.Value - 5.0);
            Assert.IsTrue(smallerCondition.IsMatchCondition(EffectWithDoubleValue));
            Condition equallCondition = new Condition("Value", "<=", (double)EffectWithDoubleValue.Value);
            Assert.IsTrue(equallCondition.IsMatchCondition(EffectWithDoubleValue));
        }
    }
}
