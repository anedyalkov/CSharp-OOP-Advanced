using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTests
{
    public class DummyTests
    {
        private const int DummyHealth = 10;
        private const int DummyExperience = 20;
      

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var attackPoints = 5;
            var dummy = new Dummy(DummyHealth, DummyExperience);

            DummyTakesAttack(dummy, attackPoints);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfDead()
        {
            var attackPoints = 11;
            var dummy = new Dummy(DummyHealth, DummyExperience);

            DummyTakesAttack(dummy, attackPoints);

            Assert.That(() => DummyTakesAttack(dummy, attackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var attackPoints = 11;
            var dummy = new Dummy(DummyHealth, DummyExperience);

            DummyTakesAttack(dummy, attackPoints);

            Assert.That(dummy.GiveExperience(),Is.EqualTo(DummyExperience));
        }

        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            var attackPoints = 5;
            var dummy = new Dummy(DummyHealth, DummyExperience);

            DummyTakesAttack(dummy, attackPoints);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        private static void DummyTakesAttack(Dummy dummy, int attackPoints)
        {
            dummy.TakeAttack(attackPoints);
        }
    }
}
