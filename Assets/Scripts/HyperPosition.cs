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
}

public enum Direction {
    east, west, up, down, north, south, left, right
}

enum WorldOrientations {
    xyz, xyw, yzw, xzw
}
