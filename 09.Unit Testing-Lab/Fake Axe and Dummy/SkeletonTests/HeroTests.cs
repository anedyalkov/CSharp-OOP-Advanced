namespace SkeletonTests
{
    using Moq;
    using NUnit.Framework;
    using System;

    public class HeroTests
    {
        [Test]
        public void HeroGainsXPWhenTheTargetDies()
        {
            ITarget target = new FakeTarget();
            IWeapon weapon = new FakeWeapon();
            var hero = new Hero("Ivan", weapon);

            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

        [Test]
        public void HeroGainsXPWhenTargetDiesWithMock()
        {

            var faketarget = new Mock<ITarget>();
            faketarget.Setup(t => t.Health).Returns(0);
            faketarget.Setup(t => t.IsDead()).Returns(true);
            faketarget.Setup(t => t.GiveExperience()).Returns(20);

            var fakeweapon = new Mock<IWeapon>();

            var hero = new Hero("Pesho", fakeweapon.Object);

            hero.Attack(faketarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

        class FakeTarget : ITarget
        {
            public int Health => 0;

            public int GiveExperience()
            {
                return 20;
            }

            public bool IsDead()
            {
                return true;
            }

            public void TakeAttack(int attackPoints)
            {
                
            }
        }

        class FakeWeapon : IWeapon
        {
            public int AttackPoints => throw new NotImplementedException();

            public int DurabilityPoints => throw new NotImplementedException();

            public void Attack(ITarget target)
            {
                
            }
        }
    }
}
