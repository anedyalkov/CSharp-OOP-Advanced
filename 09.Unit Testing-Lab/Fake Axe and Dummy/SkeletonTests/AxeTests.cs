namespace SkeletonTests
{
    using NUnit.Framework;

    public class AxeTests
    {
        private const int axeAttackPoints = 5;
        private const int firstTestAxeDurability = 10;
        private const int secondTestAxeDurability = 1;
        private const int dummyHealth = 10;
        private const int dummyExperience = 20;

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {

            Axe axe = new Axe(axeAttackPoints, firstTestAxeDurability);
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9),"Axe durability does not change after attack.");
        }

        [Test]
        public void DummyIsAttackedWithBrokenWeapon()
        {
            Axe axe = new Axe(axeAttackPoints, secondTestAxeDurability);
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
