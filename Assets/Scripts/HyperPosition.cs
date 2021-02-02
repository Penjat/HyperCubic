using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct HyperPosition {
    readonly public int x;
    readonly public int y;
    readonly public int z;
    readonly public int w;

    public HyperPosition(int x, int y, int z, int w) {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public HyperPosition moveForward(Direction direction, int amount = 1) {
        switch (direction) {
            case Direction.east:
                return new HyperPosition(this.x + amount, this.y, this.z, this.w);
            case Direction.west:
                return new HyperPosition(this.x - amount, this.y, this.z, this.w);
            case Direction.up:
                return new HyperPosition(this.x, this.y + amount, this.z, this.w);
            case Direction.down:
                return new HyperPosition(this.x, this.y - amount, this.z, this.w);
            case Direction.north:
                return new HyperPosition(this.x, this.y, this.z + amount, this.w);
            case Direction.south:
                return new HyperPosition(this.x, this.y, this.z - amount, this.w);
            case Direction.left:
                return new HyperPosition(this.x, this.y, this.z, this.w + amount);
            case Direction.right:
                return new HyperPosition(this.x, this.y, this.z, this.w - amount);
        }
        return this;
    }
}

public readonly struct HyperDirection {
    public readonly Direction facing;
    public readonly Direction standing;
    public readonly Direction toSide;
    public readonly Direction unSeen;

    public HyperDirection(Direction facing, Direction standing, Direction toSide, Direction unSeen) {
        this.facing = facing;
        this.standing = standing;
        this.toSide = toSide;
        this.unSeen = unSeen;
    }

    public HyperDirection rotate(PlayerRotation rotateDirection) {
        switch (rotateDirection) {
            case PlayerRotation.toRightSide:
            return new HyperDirection(this.toSide, this.standing, DirectionOpposite(this.facing), this.unSeen);

            case PlayerRotation.toLeftSide:
            return new HyperDirection(DirectionOpposite(this.toSide), this.standing, this.facing, this.unSeen);

            default:
            return this;
        }
    }

    static Direction DirectionOpposite(Direction direction){
        switch(direction){
            case Direction.east:
            return Direction.west;
            case Direction.west:
            return Direction.east;
            case Direction.up:
            return Direction.down;
            case Direction.down:
            return Direction.up;
            case Direction.left:
            return Direction.right;
            case Direction.right:
            return Direction.left;
            case Direction.north:
            return Direction.south;
            case Direction.south:
            return Direction.north;
        }
        return direction;
    }
}

public enum PlayerRotation {
    toRightSide, toLeftSide, toGround, toSky, toUnseen
}

public enum Direction {
    east, west, up, down, north, south, left, right
}

enum WorldOrientations {
    xyz, xyw, yzw, xzw
}
