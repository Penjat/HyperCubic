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
        Assert.AreEqual(newDir.standing, Direction.up);
        Assert.AreEqual(newDir.facing, Direction.north);
        Assert.AreEqual(newDir.toSide, Direction.west);
    }

    [Test]
    public void RotateDirectionPositive360() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(true);
        HyperDirection newDir2 = newDir1.rotate(true);
        HyperDirection newDir3 = newDir2.rotate(true);
        HyperDirection newDir4 = newDir3.rotate(true);

        Assert.AreEqual(newDir1.facing, Direction.north);
        Assert.AreEqual(newDir2.facing, Direction.west);
        Assert.AreEqual(newDir3.facing, Direction.south);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionNegative360() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(false);
        HyperDirection newDir2 = newDir1.rotate(false);
        HyperDirection newDir3 = newDir2.rotate(false);
        HyperDirection newDir4 = newDir3.rotate(false);

        Assert.AreEqual(newDir1.facing, Direction.south);
        Assert.AreEqual(newDir2.facing, Direction.west);
        Assert.AreEqual(newDir3.facing, Direction.north);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionForwardBack() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(true);
        HyperDirection newDir2 = newDir1.rotate(false);
        HyperDirection newDir3 = newDir2.rotate(false);
        HyperDirection newDir4 = newDir3.rotate(true);

        Assert.AreEqual(newDir1.facing, Direction.north);
        Assert.AreEqual(newDir2.facing, Direction.east);
        Assert.AreEqual(newDir3.facing, Direction.south);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionManyTime() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);


        for(int i=0;i<1024;i++){
            dir = dir.rotate(true);
        }
        Assert.AreEqual(dir.facing, Direction.east);
    }
}
