using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct HyperPosition: System.IEquatable<HyperPosition> {
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

    public HyperPosition move(Direction direction, int amount = 1) {
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
    public string printOut() {
        return "X: " + x + ". Y: " + y + ". Z: " + z + ". W: " + w;
    }

    // Equatable
    public static bool operator == (HyperPosition item1, HyperPosition item2){
        return (item1.x == item2.x && item1.y == item2.y && item1.z == item2.z && item1.w == item2.w);
    }
    public static bool operator !=(HyperPosition item1, HyperPosition item2){
      return !(item1 == item2);
    }
    public bool Equals(HyperPosition other) {
        return (this == other);
    }
}
