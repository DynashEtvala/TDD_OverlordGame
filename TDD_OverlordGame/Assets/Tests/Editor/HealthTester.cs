using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthTester
    {
        private void Setup(out GameObject gameObject, out Health health)
        {
            gameObject = TestSetup.CreateEmptyTestObject();
            health = gameObject.AddComponent<Health>();
        }

        [Test]
        public void T00_SimplePasses()
        {
            Assert.That(0, Is.EqualTo(0));
        }

        [Test]
        public void T01_HealthIsCreated()
        {
            Setup(out GameObject gameObject, out Health health);

            Assert.That(health, Is.Not.Null);
        }

        [Test]
        public void T02_DefaultConstructorStartsWith100Health()
        {
            Setup(out GameObject gameObject, out Health health);

            Assert.That(health.GetMaxHealth(), Is.EqualTo(100));
        }

        [Test]
        public void T03_CanSetMaxHealth([Values(1, 10, 99, 1423432)] int healthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetMaxHealth(healthVal);

            Assert.That(health.GetMaxHealth(), Is.EqualTo(healthVal));
        }

        [Test]
        public void T04_MaxHealthCannotBeSetBelow1([Values(1, 0, -1, -20, 243, -523)] int healthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetMaxHealth(healthVal);

            Assert.That(health.GetMaxHealth(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void T05_CurrentHealthIsSetToMaxHealthOnReset()
        {
            Setup(out GameObject gameObject, out Health health);

            Assert.That(health.GetCurrentHealth(), Is.EqualTo(health.GetMaxHealth()));
        }

        [Test]
        public void T06_CurrentHealthCanBeSet()
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetCurrentHealth(50);

            Assert.That(health.GetCurrentHealth(), Is.EqualTo(50));
        }

        [Test]
        public void T07_CurrentHealthCantBeSetAboveMaxHealth_Default([Values(1, 0, -1, -20, 232, -523)] int healthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetCurrentHealth(healthVal);

            Assert.That(health.GetCurrentHealth(), Is.LessThanOrEqualTo(health.GetMaxHealth()));
        }

        [Test]
        public void T08_CurrentHealthCantBeSetAboveMaxHealth_Variable([Values(1, 0, -1, -20, 232, -523)] int currentHealthVal, [Values(1, 0, -1, -20, 232, -523)] int maxHealthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetCurrentHealth(currentHealthVal);

            Assert.That(health.GetCurrentHealth(), Is.LessThanOrEqualTo(health.GetMaxHealth()));
        }

        [Test]
        public void T09_CurrentHealthCantBeSetBelow0([Values(1, 0, -1, -20, 232, -523)] int healthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetCurrentHealth(healthVal);

            Assert.That(health.GetCurrentHealth(), Is.GreaterThanOrEqualTo(0));
        }

        [Test, Pairwise]
        public void T10_CanReturnCurrentHealthAsPercentile([Values(100, 50, 25)] int healthVal)
        {
            Setup(out GameObject gameObject, out Health health);

            health.SetCurrentHealth(healthVal);

            Assert.That(health.GetHealthPercent(), Is.EqualTo((float)healthVal/100));
        }

        [Test]
        public void T11_AddsSelfToHealthManagerOnCreation()
        {
            HealthManager.Initialize();

            Assert.That(HealthManager.GetHealthCount(), Is.EqualTo(0));

            Setup(out GameObject gameObject, out Health health);

            Assert.That(HealthManager.GetHealthCount, Is.EqualTo(1));
        }
    }
}
