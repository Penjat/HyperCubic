using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HyperDirectionTests {
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

        HyperDirection newDir = dir.rotate(PlayerRotation.toRightSide);

        Assert.AreEqual(dir.facing, Direction.east);
        Assert.AreEqual(newDir.standing, Direction.up);
        Assert.AreEqual(newDir.facing, Direction.north);
        Assert.AreEqual(newDir.toSide, Direction.west);
    }

    [Test]
    public void RotateDirectionPositive360() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(PlayerRotation.toRightSide);
        HyperDirection newDir2 = newDir1.rotate(PlayerRotation.toRightSide);
        HyperDirection newDir3 = newDir2.rotate(PlayerRotation.toRightSide);
        HyperDirection newDir4 = newDir3.rotate(PlayerRotation.toRightSide);

        Assert.AreEqual(newDir1.facing, Direction.north);
        Assert.AreEqual(newDir2.facing, Direction.west);
        Assert.AreEqual(newDir3.facing, Direction.south);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionNegative360() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(PlayerRotation.toLeftSide);
        HyperDirection newDir2 = newDir1.rotate(PlayerRotation.toLeftSide);
        HyperDirection newDir3 = newDir2.rotate(PlayerRotation.toLeftSide);
        HyperDirection newDir4 = newDir3.rotate(PlayerRotation.toLeftSide);

        Assert.AreEqual(newDir1.facing, Direction.south);
        Assert.AreEqual(newDir2.facing, Direction.west);
        Assert.AreEqual(newDir3.facing, Direction.north);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionForwardBack() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        HyperDirection newDir1 = dir.rotate(PlayerRotation.toRightSide);
        HyperDirection newDir2 = newDir1.rotate(PlayerRotation.toLeftSide);
        HyperDirection newDir3 = newDir2.rotate(PlayerRotation.toLeftSide);
        HyperDirection newDir4 = newDir3.rotate(PlayerRotation.toRightSide);

        Assert.AreEqual(newDir1.facing, Direction.north);
        Assert.AreEqual(newDir2.facing, Direction.east);
        Assert.AreEqual(newDir3.facing, Direction.south);
        Assert.AreEqual(newDir4.facing, Direction.east);
    }

    [Test]
    public void RotateDirectionManyTime() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);

        for(int i=0;i<1024;i++){
            dir = dir.rotate(PlayerRotation.toRightSide);
        }
        Assert.AreEqual(dir.facing, Direction.east);
    }

    [Test]
    public void RotateLeftRight() {
        HyperDirection dir = new HyperDirection(Direction.left, Direction.north, Direction.up, Direction.east);

        HyperDirection newDir1 = dir.rotate(PlayerRotation.toRightSide);

        Assert.AreEqual(newDir1.facing, Direction.up);
        Assert.AreEqual(newDir1.toSide, Direction.right);

        HyperDirection newDir2 = newDir1.rotate(PlayerRotation.toRightSide);
        Assert.AreEqual(newDir2.facing, Direction.right);
        Assert.AreEqual(newDir2.toSide, Direction.down);
    }
}
