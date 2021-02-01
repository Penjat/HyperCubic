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
        HyperPosition pos = new HyperPosition(HyperPosition.XDirection.east, HyperPosition.YDirection.up, HyperPosition.ZDirection.north, HyperPosition.WDirection.left);
    }

    [Test]
    public void TestCanCreateHyperPositionXYZW()
    {
        HyperPosition pos = new HyperPosition(
        HyperPosition.XDirection.east,
        HyperPosition.YDirection.up,
        HyperPosition.ZDirection.north,
        HyperPosition.WDirection.left);

        Assert.AreEqual(HyperDirection.east, pos.facing);
        Assert.AreEqual(HyperDirection.up, pos.standing);
        Assert.AreEqual(HyperDirection.north, pos.toSide);
        Assert.AreEqual(HyperDirection.left, pos.unSeen);
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
