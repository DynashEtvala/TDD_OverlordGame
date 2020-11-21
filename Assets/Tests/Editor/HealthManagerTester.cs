using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthManagerTester
    {
        private void SetupMockHealth(out GameObject gameObject, out IHealth health)
        {
            gameObject = TestSetup.CreateEmptyTestObject();
            health = Substitute.For<IHealth>();
        }

        [Test]
        public void T00_SimplePasses()
        {
            Assert.AreEqual(1, 1);
        }


        [Test]
        public void T01_GetHealthCount0()
        {
            HealthManager.Initialize();

            Assert.That(HealthManager.GetHealthCount(), Is.EqualTo(0));
        }

        [Test]
        public void T02_CanAddHealthToTable()
        {
            HealthManager.Initialize();
            SetupMockHealth(out GameObject gameObject, out IHealth health);

            Assert.That(HealthManager.GetHealthCount(), Is.EqualTo(0));

            HealthManager.AddToTable(health, gameObject.transform);

            Assert.That(HealthManager.GetHealthCount(), Is.EqualTo(1));
        }

        [Test]
        public void T03_CanRetrieveHealthFromTable()
        {
            HealthManager.Initialize();
            SetupMockHealth(out GameObject gameObject, out IHealth healthInitial);
            IHealth healthReturned;

            HealthManager.AddToTable(healthInitial, gameObject.transform);
            healthReturned = HealthManager.GetFromTable(gameObject.transform);

            Assert.That(healthReturned, Is.SameAs(healthInitial));
        }

        [Test]
        public void T04_CanRemoveHealthFromTable()
        {
            HealthManager.Initialize();
            SetupMockHealth(out GameObject gameObject, out IHealth health);

            HealthManager.AddToTable(health, gameObject.transform);

            Assert.That(HealthManager.GetHealthCount, Is.EqualTo(1));

            HealthManager.RemoveFromTable(gameObject.transform);

            Assert.That(HealthManager.GetHealthCount, Is.EqualTo(0));
        }
    }
}
