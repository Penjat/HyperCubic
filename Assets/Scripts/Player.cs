using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    readonly public HyperPosition position;
    readonly public HyperDirection direction;

    public Player(HyperPosition position, HyperDirection direction) {
        this.position = position;
        this.direction = direction;
    }

    public void move(MoveResult moveResult){
        switch (moveResult) {
            case MoveResult.upward:
            //check direction
            break;
            case MoveResult.forward:
            // position = HyperPosition(position.facing + 1, position.standing, position.toSide, position.unSeen);
            break;
            case MoveResult.downward:
            //check direction
            break;
        }
    }
}
