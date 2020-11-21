using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSetupTester
    {
        [Test]
        public void T00_SimplePasses()
        {
            Assert.That(0, Is.EqualTo(0));
        }

        [Test]
        public void T01_CreateOverlordWorks()
        {
            GameObject gameObject = TestSetup.CreateOverlord();

            Assert.That(gameObject, Is.Not.Null);
        }

        [Test]
        public void T02_CreateEmptyTestObjectWorks()
        {
            GameObject gameObject = TestSetup.CreateEmptyTestObject();

            Assert.That(gameObject, Is.Not.Null);
        }
    }
}
