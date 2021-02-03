using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTests {

    [Test]
    public void TestGameMovesPlayerDownAndForward() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(5,5,5,5);
        HyperPosition playerPosition = new HyperPosition(0,1,0,0);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);
        hyperGrid.setBlocked(0,0,0,0);

        //When
        game.process(MoveIntent.forward);

        //Then
        Assert.AreEqual(new HyperPosition(1,0,0,0), player.position);
    }

    [Test]
    public void TestGameMovesPlayerFourTimes() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        HyperPosition playerPosition = new HyperPosition(5,5,5,5);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);
        hyperGrid.setBlocked(5,4,5,5);

        // When
        game.process(MoveIntent.forward);
        game.process(MoveIntent.forward);
        game.process(MoveIntent.forward);

        //Then
        Assert.AreEqual(new HyperPosition(4,4,5,5), player.position);
        Assert.AreEqual(new HyperDirection(Direction.up,Direction.west,Direction.north,Direction.left), player.direction);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,5,5,5), player.position);
    }

    [Test]
    public void TestWalkForward() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(8,8,8,8);
        HyperPosition playerPosition = new HyperPosition(0,1,0,3);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);

        for(int x=0;x<7;x++){
            hyperGrid.setBlocked(x,0,0,3);
        }

        //When
        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,1,0,3), player.position, player.position.printOut());
        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(2,1,0,3), player.position, player.position.printOut());
        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,1,0,3), player.position, player.position.printOut());
        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(4,1,0,3), player.position, player.position.printOut());

        //Then
        Assert.AreEqual(new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left), player.direction);
    }

    [Test]
    public void TestWalkInCircle() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        HyperPosition playerPosition = new HyperPosition(2,2,2,0);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);

        hyperGrid.setBlocked(2,1,2,0);
        hyperGrid.setBlocked(3,1,2,0);
        hyperGrid.setBlocked(4,1,2,0);
        hyperGrid.setBlocked(5,1,2,0);

        hyperGrid.setBlocked(5,1,3,0);
        hyperGrid.setBlocked(5,1,4,0);
        hyperGrid.setBlocked(5,1,5,0);
        hyperGrid.setBlocked(5,1,6,0);

        hyperGrid.setBlocked(4,1,6,0);
        hyperGrid.setBlocked(3,1,6,0);
        hyperGrid.setBlocked(2,1,6,0);
        hyperGrid.setBlocked(1,1,6,0);

        hyperGrid.setBlocked(1,1,5,0);
        hyperGrid.setBlocked(1,1,4,0);
        hyperGrid.setBlocked(1,1,3,0);
        hyperGrid.setBlocked(1,1,2,0);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,2,2,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(4,2,2,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,2,2,0), player.position, player.position.printOut());

        game.process(MoveIntent.turnRightSide);
        Assert.AreEqual(new HyperPosition(5,2,2,0), player.position, player.position.printOut());
        Assert.AreEqual(new HyperDirection(Direction.north,Direction.up,Direction.west,Direction.left), player.direction);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,2,3,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,2,4,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,2,5,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(5,2,6,0), player.position, player.position.printOut());

        game.process(MoveIntent.turnRightSide);
        Assert.AreEqual(new HyperPosition(5,2,6,0), player.position, player.position.printOut());
        Assert.AreEqual(new HyperDirection(Direction.west,Direction.up,Direction.south,Direction.left), player.direction);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(4,2,6,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,2,6,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(2,2,6,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,2,6,0), player.position, player.position.printOut());

        game.process(MoveIntent.turnRightSide);
        Assert.AreEqual(new HyperPosition(1,2,6,0), player.position, player.position.printOut());
        Assert.AreEqual(new HyperDirection(Direction.south,Direction.up,Direction.east,Direction.left), player.direction);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,2,5,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,2,4,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,2,3,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(1,2,2,0), player.position, player.position.printOut());
    }

    [Test]
    public void TestPlayerMovesUp() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        HyperPosition playerPosition = new HyperPosition(2,2,2,0);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);

        hyperGrid.setBlocked(2,1,2,0);
        hyperGrid.setBlocked(3,1,2,0);
        hyperGrid.setBlocked(4,2,2,0);
        hyperGrid.setBlocked(4,3,2,0);

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,2,2,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,2,2,0), player.position, player.position.printOut());

        game.process(MoveIntent.forward);
        Assert.AreEqual(new HyperPosition(3,3,2,0), player.position, player.position.printOut());
    }
}
