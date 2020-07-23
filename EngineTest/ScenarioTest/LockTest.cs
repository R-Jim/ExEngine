using ExtiliaEngine;
using NUnit.Framework;

namespace EngineTest.ScenarioTest
{
    class LockTest
    {
        Instance WeaponLockInstance;
        Instance WeaponLockInvokerInstance;

        [SetUp]
        public void WeaponLockInvokerInstanceSetup()
        {
            string[] types = new string[] { "Damage", "Weapon1" };
            WeaponLockInvokerInstance = LockInvoker.Get("Weapon1", types, 10);
        }


        [SetUp]
        public void WeaponLockInstanceSetup()
        {
            WeaponLockInstance = Lock.Get("Weapon1", "Weapon1");
        }

        [Test]
        public void WeaponLock()
        {
            Effect damageEffect = new Effect(
                new string[] { "Damage", "Weapon1" },
                new Coordinate(1, 1),
                20.0
                );
            Effect lockEffect = WeaponLockInvokerInstance.OnEffect(damageEffect);
            WeaponLockInstance.OnEffect(lockEffect);
            Assert.AreEqual(WeaponLockInstance.Value, 10);
        }
    }
}
