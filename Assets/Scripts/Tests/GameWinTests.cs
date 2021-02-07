using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameWinTests {
    [Test]
    public void PlayerOnWinPlayerWins() {
        // Given
        HyperPosition playerStart = new HyperPosition(0,0,0,0);
        Player player = new Player(playerStart, HyperDirection.normal);

        HyperGrid hyperGrid = new HyperGrid(8,8,8,8);
        Game game = new Game(player, hyperGrid, new HyperPosition(0,0,0,0));

        Assert.IsTrue(game.checkWon());
    }

    [Test]
    public void PlayerNotOnWinPlayerDoesntWin() {
        // Given
        HyperPosition playerStart = new HyperPosition(0,0,0,0);
        Player player = new Player(playerStart, HyperDirection.normal);

        HyperGrid hyperGrid = new HyperGrid(8,8,8,8);
        Game game = new Game(player, hyperGrid, new HyperPosition(3,3,3,3));

        Assert.IsFalse(game.checkWon());
    }
}
