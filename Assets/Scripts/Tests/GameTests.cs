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
    public void TestGameMovesPlayerThreeTimes() {
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
    }
}
