using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct HyperPosition {
    public readonly HyperDirection facing;
    public readonly HyperDirection standing;
    public readonly HyperDirection toSide;
    public readonly HyperDirection  unSeen;
    
    public HyperPosition(XDirection facing, YDirection standing, ZDirection toSide, WDirection unSeen) {
        this.facing = (facing == XDirection.east) ? HyperDirection.east : HyperDirection.west;
        this.standing = (standing == YDirection.up) ? HyperDirection.up : HyperDirection.down;
        this.toSide = (toSide == ZDirection.north) ? HyperDirection.north : HyperDirection.south;
        this.unSeen = (unSeen == WDirection.left) ? HyperDirection.left : HyperDirection.right;
    }

    public enum XDirection {
        east, west
    }
    public enum YDirection {
        up, down
    }
    public enum ZDirection {
        north, south
    }
    public enum WDirection {
        left, right
    }
}

public enum HyperDirection {
    east, west, up, down, north, south, left, right
}


enum WorldOrientations {
    xyz, xyw, yzw, xzw
}
