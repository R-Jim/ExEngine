using ExtiliaEngine;
using NUnit.Framework;

namespace EngineTest.ScenarioTest
{
    class LockTest
    {
        Instance WeaponInstance;
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

        [SetUp]
        public void WeaponInstanceSetup()
        {
            WeaponInstance = Weapon.Get("1", 50.0, CoordinateInstance.Get("1", new Coordinate(0, 0), null), WeaponLockInstance);

        }
        [Test]
        public void WeaponOn()
        {
            //Effect damageEffect = new Effect(
            //    new string[] { "Damage", "Weapon1" },
            //    new Coordinate(1, 1),
            //    20.0
            //    );
            //Effect lockEffect = WeaponLockInvokerInstance.OnEffect(damageEffect);
            //WeaponLockInstance.OnEffect(lockEffect);
            //Assert.AreEqual(WeaponLockInstance.Value, 10);

            Effect attackEffect = new Effect(
                new string[] { "Attack", "1" },
                null,
                new Coordinate(1.0, 1.0)
                );
            Assert.IsNotNull(WeaponInstance.OnEffect(attackEffect));
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
            Assert.AreEqual(10, WeaponLockInstance.Value);

            Effect attackEffect = new Effect(
                new string[] { "Attack", "1" },
                null,
                new Coordinate(1.0, 1.0)
                );
            Assert.IsNull(WeaponInstance.OnEffect(attackEffect));
        }
    }
}
