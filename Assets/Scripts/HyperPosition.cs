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

public readonly struct HyperDirection: System.IEquatable<HyperDirection> {
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

            case PlayerRotation.toGround:
            return new HyperDirection(DirectionOpposite(this.standing), this.facing, this.toSide, this.unSeen);

            case PlayerRotation.toSky:
            return new HyperDirection(this.standing, DirectionOpposite(this.facing), this.toSide, this.unSeen);

            case PlayerRotation.toUnseenRight:
            return new HyperDirection(this.unSeen, this.standing, this.toSide, DirectionOpposite(this.facing));

            case PlayerRotation.toUnseenLeft:
            return new HyperDirection(DirectionOpposite(this.unSeen), this.standing, this.toSide, this.facing);
        }
        return this;
    }

    public string discription() {
        return ("facing: " + directionDiscription(facing) + ". standing: " + directionDiscription(standing) + ". toSide: " + directionDiscription(toSide) + ". unSeen: " + unSeen);
    }

    static Direction DirectionOpposite(Direction direction) {
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
        return Direction.south ;
    }
    static string directionDiscription(Direction direction) {
        switch (direction){
            case Direction.east:
            return "East";
            case Direction.west:
            return "West";
            case Direction.up:
            return "Up";
            case Direction.down:
            return "Down";
            case Direction.north:
            return "North";
            case Direction.south:
            return "South";
            case Direction.left:
            return "Left";
            case Direction.right:
            return "Right";
        }
        return "error";
    }
    public static bool operator ==(HyperDirection x, HyperDirection y){
      return x.facing == y.facing && x.standing == y.standing && x.toSide == y.toSide && x.unSeen == y.unSeen;
    }
    public static bool operator !=(HyperDirection x, HyperDirection y){
      return !(x == y);
    }
    public bool Equals(HyperDirection other) {
        return this.facing == other.facing && this.standing == other.standing && this.toSide == other.toSide && this.unSeen == other.unSeen;
    }
}

public enum PlayerRotation {
    toRightSide, toLeftSide, toGround, toSky, toUnseenLeft, toUnseenRight
}

public enum Direction {
    east, west, up, down, north, south, left, right
}

enum WorldOrientations {
    xyz, xyw, yzw, xzw
}
