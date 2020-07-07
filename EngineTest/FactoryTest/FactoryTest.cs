using NUnit.Framework;

namespace EngineTest.FactoryTest
{
    class FactoryTest
    {
        public Effect DoubleValueEffect;
        public Effect CoordinateValueEffect;

        [SetUp]
        public void Setup_DoubleValue_Effect()
        {
            DoubleValueEffect = new Effect(new string[] { "Sample" },
                new Coordinate(1, 1),
                10.0);
        }

        [SetUp]
        public void Setup_CoordinateValue_Effect()
        {
            CoordinateValueEffect = new Effect(new string[] { "Sample" },
                new Coordinate(1, 1),
                 new Coordinate(1, 1));
        }

        [Test]
        public void BaseValue_FactoryTest()
        {
            double inputValue = 0;
            Factory factory = new Factory(inputValue);
            Assert.AreEqual(inputValue, factory.GetValue(DoubleValueEffect));
        }

        [Test]
        public void FieldPath_EffectDoubleValue_FactoryTest()
        {
            Factory factory = new Factory("Value");
            Assert.AreEqual(DoubleValueEffect.Value, factory.GetValue(DoubleValueEffect));
        }

        [Test]
        public void FieldPath_EffectDoubleValue_AdditionModify_FactoryTest()
        {
            double inputValue = 5;
            Factory factory = new Factory("Value", inputValue, "+");
            Assert.AreEqual(
                (double)DoubleValueEffect.Value + inputValue,
                factory.GetValue(DoubleValueEffect));
        }

        [Test]
        public void FieldPath_EffectDoubleValue_MultiplyModify_FactoryTest()
        {
            double inputValue = 5;
            Factory factory = new Factory("Value", inputValue, "*");
            Assert.AreEqual(
                (double)DoubleValueEffect.Value * inputValue,
                factory.GetValue(DoubleValueEffect));
        }

        [Test]
        public void FieldPath_EffectCoordinateValue_AdditionModify_FactoryTest()
        {
            Coordinate inputValue = new Coordinate(2, 5);
            Factory factory = new Factory("Value", inputValue, "+");
            Assert.AreEqual(
                new Coordinate(
                        inputValue.X + ((Coordinate)CoordinateValueEffect.Value).X,
                        inputValue.Y + ((Coordinate)CoordinateValueEffect.Value).Y
                    ),
                factory.GetValue(CoordinateValueEffect));
        }

        [Test]
        public void FieldPath_EffectCoordinateValue_MultiplyModify_FactoryTest()
        {
            Coordinate inputValue = new Coordinate(2, 5);
            Factory factory = new Factory("Value", inputValue, "*");
            Assert.AreEqual(
                new Coordinate(
                        inputValue.X * ((Coordinate)CoordinateValueEffect.Value).X,
                        inputValue.Y * ((Coordinate)CoordinateValueEffect.Value).Y
                    ),
                factory.GetValue(CoordinateValueEffect));
        }
    }
}
