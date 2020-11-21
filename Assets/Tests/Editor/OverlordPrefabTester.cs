using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OverlordPrefabTester
    {
        [Test]
        public void T00_SimplePasses()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void T01_OverlordIsSuccesfullyCreated()
        {
            GameObject Overlord = TestSetup.CreateOverlord();

            Assert.IsNotNull(Overlord);
        }
    }
}
