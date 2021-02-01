using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HyperDirectionTests {
    // A Test behaves as an ordinary method
    [Test]
    public void CanCreateHyperDirection() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        Assert.AreEqual(dir.facing, Direction.east);
        Assert.AreEqual(dir.standing, Direction.up);
        Assert.AreEqual(dir.toSide, Direction.north);
        Assert.AreEqual(dir.unSeen, Direction.left);
    }

    [Test]
    public void RotateDirection() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir = dir.rotate(true);

        Assert.AreEqual(dir.facing, Direction.east);
        Assert.AreEqual(newDir.facing, Direction.north);
    }
}
