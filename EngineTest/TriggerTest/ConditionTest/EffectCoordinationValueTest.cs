using NUnit.Framework;
using ExtiliaEngine;
namespace EngineTest.TriggerTest.ConditionTest
{
    class EffectCoordinationValueTest
    {
        public Effect EffectWithCoordinateValue;

        [SetUp]
        public void Setup()
        {
            EffectWithCoordinateValue = new Effect(null, null, new Coordinate(10, 10));
        }

        [Test]
        public void EqualTest()
        {
            Condition condition = new Condition("Value", "=", EffectWithCoordinateValue.Value);
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void NotEqualTest()
        {
            Condition condition = new Condition("Value", "!=", new Coordinate(0,0));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void XEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "X,=", new Coordinate(coordinate.X, 0));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "Y,=", new Coordinate(0, coordinate.Y));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void XNotEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "X,!=", new Coordinate(0, coordinate.Y));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YNotEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "Y,!=", new Coordinate(coordinate.X, 0));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }


        [Test]
        public void XLargerTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "X,>", new Coordinate(coordinate.X + 1, 0));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YLargerTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "Y,>", new Coordinate(0, coordinate.Y + 1));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void XSmallerTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "X,<", new Coordinate(coordinate.X - 1, 0));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YSmallerTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition condition = new Condition("Value", "Y,<", new Coordinate(0, coordinate.Y - 1));
            Assert.IsTrue(condition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void XLargerOrEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition largerCondition = new Condition("Value", "X,>=", new Coordinate(coordinate.X + 1, 0));
            Assert.IsTrue(largerCondition.IsMatchCondition(EffectWithCoordinateValue));
            Condition equalCondition = new Condition("Value", "X,>=", new Coordinate(coordinate.X, 0));
            Assert.IsTrue(equalCondition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YLargerOrEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition largerCondition = new Condition("Value", "Y,>=", new Coordinate(0, coordinate.Y + 1));
            Assert.IsTrue(largerCondition.IsMatchCondition(EffectWithCoordinateValue));
            Condition equalCondition = new Condition("Value", "Y,>=", new Coordinate(0, coordinate.Y));
            Assert.IsTrue(equalCondition.IsMatchCondition(EffectWithCoordinateValue));
        }


        [Test]
        public void XSmallerOrEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition smallerCondition = new Condition("Value", "X,<=", new Coordinate(coordinate.X - 1, 0));
            Assert.IsTrue(smallerCondition.IsMatchCondition(EffectWithCoordinateValue));
            Condition equalCondition = new Condition("Value", "X,<=", new Coordinate(coordinate.X, 0));
            Assert.IsTrue(equalCondition.IsMatchCondition(EffectWithCoordinateValue));
        }

        [Test]
        public void YSmallerOrEqualTest()
        {
            Coordinate coordinate = (Coordinate)EffectWithCoordinateValue.Value;
            Condition smallerCondition = new Condition("Value", "Y,<=", new Coordinate(0, coordinate.Y - 1));
            Assert.IsTrue(smallerCondition.IsMatchCondition(EffectWithCoordinateValue));
            Condition equalCondition = new Condition("Value", "Y,<=", new Coordinate(0, coordinate.Y));
            Assert.IsTrue(equalCondition.IsMatchCondition(EffectWithCoordinateValue));
        }
    }
}
