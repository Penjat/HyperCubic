using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTests {

    [Test]
    public void TestGameMovesPlayer() {
        // Given
        HyperGrid hyperGrid = new HyperGrid(5,5,5,5);
        HyperPosition playerPosition = new HyperPosition(0,0,0,0);
        HyperDirection playerDirection = new HyperDirection(Direction.east,Direction.up,Direction.north,Direction.left);
        Player player = new Player(playerPosition, playerDirection);
        Game game = new Game(player, hyperGrid);

        //When
        game.process(MoveIntent.forward);
    }
}
