using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct HyperPosition {
    readonly int x;
    readonly int y;
    readonly int z;
    readonly int w;
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
