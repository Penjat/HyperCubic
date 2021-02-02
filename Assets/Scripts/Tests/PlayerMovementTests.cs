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

    [Test]
    public void MoveUpWallChangesDirectionNotPosition() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.up, Direction.west, Direction.south, Direction.left);
        HyperPosition pos = new HyperPosition(3,2,1,1);
        Player player = new Player(pos, dir);

        //When
        player.move(MoveResult.upward);

        //Then
        HyperPosition expectedPosition = new HyperPosition(3,2,1,1);
        HyperDirection expectedRotation = new HyperDirection(Direction.west, Direction.down, Direction.south, Direction.left);
        Assert.AreEqual(expectedPosition, player.position);
        Assert.AreEqual(expectedRotation, player.direction);
    }

    [Test]
    public void MoveDownChangesPositionAndRotation() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.south, Direction.left);
        HyperPosition pos = new HyperPosition(5,2,20,8);
        Player player = new Player(pos, dir);

        //When
        player.move(MoveResult.downward);

        //Then
        HyperPosition expectedPosition = new HyperPosition(6,1,20,8);
        HyperDirection expectedRotation = new HyperDirection(Direction.down, Direction.east, Direction.south, Direction.left);
        Assert.AreEqual(expectedPosition, player.position);
        Assert.AreEqual(expectedRotation, player.direction);
    }

    [Test]
    public void RotatingPlayerDoesntChangePosition() {
        //Given
        HyperDirection dir = new HyperDirection(Direction.north, Direction.right, Direction.east, Direction.down);
        HyperPosition pos = new HyperPosition(3,3,23,1);
        Player player = new Player(pos, dir);

        //When
        player.move(MoveResult.toRightSide).move(MoveResult.toUnseenLeft).move(MoveResult.toRightSide).move(MoveResult.toRightSide).move(MoveResult.toUnseenLeft).move(MoveResult.toUnseenLeft).move(MoveResult.toLeftSide);

        //Then
        Assert.AreEqual(new HyperPosition(3,3,23,1), player.position);
    }

    [Test]
    public void RotatingPlayerFourTimesIsSameSpot() {
        //Given
        HyperDirection startingDirection = new HyperDirection(Direction.north, Direction.right, Direction.east, Direction.down);
        HyperPosition pos = new HyperPosition(3,3,23,1);
        Player player = new Player(pos, startingDirection);

        player.move(MoveResult.toRightSide).move(MoveResult.toRightSide).move(MoveResult.toRightSide).move(MoveResult.toRightSide);
        Assert.AreEqual(startingDirection, player.direction);

        player.move(MoveResult.toLeftSide).move(MoveResult.toLeftSide).move(MoveResult.toLeftSide).move(MoveResult.toLeftSide);
        Assert.AreEqual(startingDirection, player.direction);

        player.move(MoveResult.toUnseenLeft).move(MoveResult.toUnseenLeft).move(MoveResult.toUnseenLeft).move(MoveResult.toUnseenLeft);
        Assert.AreEqual(startingDirection, player.direction);

        player.move(MoveResult.toUnseenRight).move(MoveResult.toUnseenRight).move(MoveResult.toUnseenRight).move(MoveResult.toUnseenRight);
        Assert.AreEqual(startingDirection, player.direction);
    }

    [Test]
    public void PlayerMoveForwardTwiceTurnLeftAndThenUp() {
        //Given
        HyperDirection startingDirection = new HyperDirection(Direction.north, Direction.right, Direction.east, Direction.down);
        HyperPosition pos = new HyperPosition(4,0,0,0);
        Player player = new Player(pos, startingDirection);

        player.move(MoveResult.forward).move(MoveResult.forward).move(MoveResult.toLeftSide).move(MoveResult.upward);

        HyperPosition expectedPosition = new HyperPosition(4,0,2,0);
        HyperDirection expectedRotation = new HyperDirection(Direction.right, Direction.east, Direction.north, Direction.down);
        Assert.AreEqual(expectedPosition, player.position);
        Assert.AreEqual(expectedRotation, player.direction, player.direction.discription());
    }

    [Test]
    public void PlayerMoveIntoUnseen() {
        //Given
        HyperDirection startingDirection = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.right);
        HyperPosition pos = new HyperPosition(0,0,0,0);
        Player player = new Player(pos, startingDirection);

        player.move(MoveResult.toUnseenRight).move(MoveResult.forward).move(MoveResult.forward).move(MoveResult.forward).move(MoveResult.forward);

        HyperPosition expectedPosition = new HyperPosition(0,0,0,-4);
        HyperDirection expectedRotation = new HyperDirection(Direction.right, Direction.up, Direction.north, Direction.west);
        Assert.AreEqual(expectedPosition, player.position);
        Assert.AreEqual(expectedRotation, player.direction);
    }
}
