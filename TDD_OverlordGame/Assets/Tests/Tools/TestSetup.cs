using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
    public static class TestSetup
    {
        public static GameObject CreateOverlord()
        {
            return Object.Instantiate(Resources.Load<GameObject>("Prefabs/Overlord"));
        }
        public static GameObject CreateEmptyTestObject()
        {
            return Object.Instantiate(Resources.Load<GameObject>("TestResources/Prefabs/EmptyTestObject"));
        }
    }
}
