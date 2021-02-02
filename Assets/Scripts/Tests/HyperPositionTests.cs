using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HyperPositionTests {

    [Test]
    public void TestCanCreateHyperPositionXYZW() {
        HyperDirection pos = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        Assert.AreEqual(Direction.east, pos.facing);
        Assert.AreEqual(Direction.up, pos.standing);
        Assert.AreEqual(Direction.north, pos.toSide);
        Assert.AreEqual(Direction.left, pos.unSeen);
    }
}
