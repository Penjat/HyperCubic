using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests {
    [Test]
    public void CreatePlayerWithPosition() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);
        HyperPosition pos = new HyperPosition(0,5,0,4);
        Player player = new Player(pos, dir);

        //Then
        Assert.AreEqual(player.position.x, 0);
        Assert.AreEqual(player.position.y, 5);
        Assert.AreEqual(player.position.z, 0);
        Assert.AreEqual(player.position.w, 4);

        Assert.AreEqual(player.direction.facing, Direction.east);
        Assert.AreEqual(player.direction.standing, Direction.up);
        Assert.AreEqual(player.direction.toSide, Direction.north);
        Assert.AreEqual(player.direction.unSeen, Direction.left);
    }

    [Test]
    public void MovePlayerEast() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);
        HyperPosition pos = new HyperPosition(6,2,1,1);

        Player player = new Player(pos, dir);
        Assert.AreEqual(player.position.x, 6);

        //When
        player.move(MoveResult.forward);

        //Then
        Assert.AreEqual(player.position.x, 7);
        Assert.AreEqual(player.position.y, 2);
        Assert.AreEqual(player.position.z, 1);
        Assert.AreEqual(player.position.w, 1);
    }

    [Test]
    public void MovePlayerWest() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.west, Direction.up, Direction.north, Direction.left);
        HyperPosition pos = new HyperPosition(6,2,1,1);
        Player player = new Player(pos, dir);
        Assert.AreEqual(player.position.x, 6);

        //When
        player.move(MoveResult.forward);

        //Then
        Assert.AreEqual(player.position.x, 5);
    }

    [Test]
    public void MovePlayerNorth() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.north, Direction.up, Direction.west, Direction.left);
        HyperPosition pos = new HyperPosition(6,2,1,1);
        Player player = new Player(pos, dir);
        Assert.AreEqual(player.position.z, 1);

        //When
        player.move(MoveResult.forward);

        //Then
        Assert.AreEqual(player.position.z, 2);
    }

    [Test]
    public void MovePlayerForwardFourTimes() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.up, Direction.west, Direction.south, Direction.left);
        HyperPosition pos = new HyperPosition(3,2,1,1);
        Player player = new Player(pos, dir);
        Assert.AreEqual(player.position.y, 2);

        //When
        player.move(MoveResult.forward);
        player.move(MoveResult.forward);
        player.move(MoveResult.forward);
        player.move(MoveResult.forward);

        //Then
        Assert.AreEqual(player.position.y, 6);
    }
}
