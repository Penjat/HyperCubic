using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public HyperPosition position { get; private set; }
    public HyperDirection direction { get; private set; }

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
            this.position = position.moveForward(direction.facing);
            break;
            case MoveResult.downward:
            //check direction
            break;
        }
    }
}
