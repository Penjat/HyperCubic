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

    public Player move(MoveResult moveResult){
        switch (moveResult) {
            case MoveResult.upward:
            this.direction = this.direction.rotate(PlayerRotation.toSky);
            break;

            case MoveResult.forward:
            this.position = position.move(direction.facing);
            break;

            case MoveResult.downward:
            this.position = position.move(direction.facing).move(direction.standing, -1);
            this.direction = direction.rotate(PlayerRotation.toGround);
            break;

            case MoveResult.toLeftSide:
            this.direction = direction.rotate(PlayerRotation.toLeftSide);
            break;

            case MoveResult.toRightSide:
            this.direction = direction.rotate(PlayerRotation.toRightSide);
            break;

            case MoveResult.toUnseenLeft:
            this.direction = direction.rotate(PlayerRotation.toUnseenLeft);
            break;

            case MoveResult.toUnseenRight:
            this.direction = direction.rotate(PlayerRotation.toUnseenRight);
            break;
        }
        return this;
    }
}
