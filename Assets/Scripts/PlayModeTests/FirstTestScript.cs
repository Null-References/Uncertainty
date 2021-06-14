using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FirstTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FirstTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator timer_after_01_seconds()
        {
            RepeatableTimer timer = new RepeatableTimer(0.1f);
            timer.Tick(0.1f);
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(timer.IsReady());
        }
        [UnityTest]
        public IEnumerator timer_zero_duration()
        {
            RepeatableTimer timer = new RepeatableTimer(0);
            timer.Tick(0);
            yield return null;
            Assert.IsTrue(timer.IsReady());
        }
    }
}
