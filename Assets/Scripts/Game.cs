using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveIntent {
    forward, turnRightSide, turnLeftSide, turnRightUnseen, turnLeftUnseen
}

public class Game {
    Player player;
    HyperGrid hyperGrid;
    public Game(Player player, HyperGrid hyperGrid) {
        this.player = player;
        this.hyperGrid = hyperGrid;
    }

    public void process(MoveIntent intent) {
        switch (intent) {
            case MoveIntent.forward:
            HyperPosition inFront = player.position.move(player.direction.facing);
            HyperPosition inFrontBelow = inFront.move(player.direction.standing, -1);

            if(hyperGrid.checkBlocked(inFront)) {
                player.move(MoveResult.upward);
            } else if (hyperGrid.checkBlocked(inFrontBelow)) {
                player.move(MoveResult.forward);
            } else {
                player.move(MoveResult.downward);
            }
            break;

            case MoveIntent.turnRightSide:
            player.move(MoveResult.toRightSide);
            break;

            case MoveIntent.turnLeftSide:
            player.move(MoveResult.toLeftSide);
            break;

            case MoveIntent.turnRightUnseen:
            player.move(MoveResult.toUnseenRight);
            break;

            case MoveIntent.turnLeftUnseen:
            player.move(MoveResult.toUnseenLeft);
            break;
        }
    }
}
