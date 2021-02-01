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
        MoveResult result1 = gridmanager.moveResult(true,true);
        Assert.AreEqual(MoveResult.upward, result1);

        MoveResult result2 = gridmanager.moveResult(true,false);
        Assert.AreEqual(MoveResult.upward, result2);
    }

    [Test]
    public void TestMoveForwardWhenNotBlocked()
    {
        GridManager gridmanager = new GridManager();
        MoveResult result = gridmanager.moveResult(false,true);
        Assert.AreEqual(MoveResult.forward, result);
    }

    [Test]
    public void TestMoveDowardWhenNotBlockedAnywhere()
    {
        GridManager gridmanager = new GridManager();
        MoveResult result = gridmanager.moveResult(false,false);
        Assert.AreEqual(MoveResult.downward, result);
    }
}
