using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class TimerTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TimerTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    [UnityTest]
    public IEnumerator Timer_After_5_Seconds()
    {
        yield return null;
    }
}
