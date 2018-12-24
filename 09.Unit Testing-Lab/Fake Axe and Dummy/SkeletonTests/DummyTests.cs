namespace SkeletonTests
{
    using NUnit.Framework;

    public class DummyTests
    {
        private const int dummyHealth = 10;
        private const int dummyExperience = 20;
        private const int firstValueAttackPoints = 5;
        private const int secondValueAttackPoints = 11;

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var dummy = new Dummy(dummyHealth, dummyExperience);

            DummyTakesAttack(dummy, firstValueAttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfDead()
        {
            var dummy = new Dummy(dummyHealth, dummyExperience);

            DummyTakesAttack(dummy, secondValueAttackPoints);

            Assert.That(() => DummyTakesAttack(dummy, secondValueAttackPoints), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var dummy = new Dummy(dummyHealth, dummyExperience);

            DummyTakesAttack(dummy, secondValueAttackPoints);

            Assert.That(dummy.GiveExperience(),Is.EqualTo(dummyExperience));
        }

        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            var dummy = new Dummy(dummyHealth, dummyExperience);

            DummyTakesAttack(dummy, firstValueAttackPoints);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        private static void DummyTakesAttack(Dummy dummy, int attackPoints)
        {
            dummy.TakeAttack(attackPoints);
        }
    }
}
