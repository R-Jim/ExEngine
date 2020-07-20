using ExtiliaEngine;
using NUnit.Framework;

namespace EngineTest.FactoryTest
{
    class EffectFactoryTest
    {
        Effect SampleEffect;
        [SetUp]
        public void SetupSampleEffect()
        {
            SampleEffect = new Effect(new string[] { "Sample" },
                new Coordinate(1, 1),
                new Coordinate(10, 10));
        }
    }
}
