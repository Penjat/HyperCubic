using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestMoveUpwardWhenBlocked()
    {
        GridManager gridmanager = new GridManager();
        MoveResut result = gridmanager.moveResult();
        Assert.AreEqual(MoveResut.upward, result);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GridTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
