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

    [Test]
    public void RotateDownFromUp() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.west, Direction.up, Direction.south, Direction.left);

        //When
        HyperDirection actual = dir.rotate(PlayerRotation.toGround);
        HyperDirection expected = new HyperDirection(Direction.down, Direction.west, Direction.south, Direction.left);

        //Then
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RotateDownFromLeft() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.left, Direction.west, Direction.south, Direction.down);

        //When
        HyperDirection actual = dir.rotate(PlayerRotation.toGround);
        HyperDirection expected = new HyperDirection(Direction.east, Direction.left, Direction.south, Direction.down);

        //Then
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RotateSkyFromStanding() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.south, Direction.left);

        //When
        HyperDirection actual = dir.rotate(PlayerRotation.toSky);
        HyperDirection expected = new HyperDirection(Direction.up, Direction.west, Direction.south, Direction.left);

        //Then
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RotateSkyFromLeftMultiple() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.left, Direction.up, Direction.south, Direction.left);

        //When
        HyperDirection actual1 = dir.rotate(PlayerRotation.toSky);
        HyperDirection expected1 = new HyperDirection(Direction.up, Direction.right, Direction.south, Direction.left);

        HyperDirection actual2 = actual1.rotate(PlayerRotation.toSky);
        HyperDirection expected2 = new HyperDirection(Direction.right, Direction.down, Direction.south, Direction.left);

        HyperDirection actual3 = actual2.rotate(PlayerRotation.toSky);
        HyperDirection expected3 = new HyperDirection(Direction.down, Direction.left, Direction.south, Direction.left);
        //Then
        Assert.AreEqual(expected1, actual1);
        Assert.AreEqual(expected2, actual2);
        Assert.AreEqual(expected3, actual3);
    }

    [Test]
    public void RotateMultipleDirections() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.left, Direction.up, Direction.south, Direction.east);

        //When
        HyperDirection actual1 = dir.rotate(PlayerRotation.toGround);
        HyperDirection expected1 = new HyperDirection(Direction.down, Direction.left, Direction.south, Direction.east);

        HyperDirection actual2 = actual1.rotate(PlayerRotation.toRightSide);
        HyperDirection expected2 = new HyperDirection(Direction.south, Direction.left, Direction.up, Direction.east);

        HyperDirection actual3 = actual2.rotate(PlayerRotation.toSky);
        HyperDirection expected3 = new HyperDirection(Direction.left, Direction.north, Direction.up, Direction.east);

        HyperDirection actual4 = actual3.rotate(PlayerRotation.toLeftSide);
        HyperDirection expected4 = new HyperDirection(Direction.down, Direction.north, Direction.left, Direction.east);

        //Then
        Assert.AreEqual(expected1, actual1);
        Assert.AreEqual(expected2, actual2);
        Assert.AreEqual(expected3, actual3);
        Assert.AreEqual(expected4, actual4);
    }

    [Test]
    public void RotateToUnseenRight() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.left, Direction.up, Direction.south, Direction.east);

        //When
        HyperDirection actual1 = dir.rotate(PlayerRotation.toUnseenRight);
        HyperDirection expected1 = new HyperDirection(Direction.east, Direction.up, Direction.south, Direction.right);

        HyperDirection actual2 = actual1.rotate(PlayerRotation.toUnseenRight);
        HyperDirection expected2 = new HyperDirection(Direction.right, Direction.up, Direction.south, Direction.west);

        HyperDirection actual3 = actual2.rotate(PlayerRotation.toUnseenRight);
        HyperDirection expected3 = new HyperDirection(Direction.west, Direction.up, Direction.south, Direction.left);

        HyperDirection actual4 = actual3.rotate(PlayerRotation.toUnseenRight);
        HyperDirection expected4 = new HyperDirection(Direction.left, Direction.up, Direction.south, Direction.east);

        //Then
        Assert.AreEqual(expected1, actual1);
        Assert.AreEqual(expected2, actual2);
        Assert.AreEqual(expected3, actual3);
        Assert.AreEqual(expected4, actual4);
    }
}
