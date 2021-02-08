using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : PiecePresenter {
    public void rotateToFace(HyperDirection hyperDirection) {
        float x = 0;
        float y = 0;
        float z = 0;

        switch (hyperDirection.standing){
            case Direction.east:
            z = 90.0f;
            break;
            case Direction.west:
            z = -90.0f;
            break;
            case Direction.north:
            x = 90.0f;
            break;
            case Direction.south:
            x = -90.0f;
            break;
        }
        transform.rotation = Quaternion.Euler(x, y, z);
    }

    public GridSlice orientationForDirection(HyperDirection hyperDirection, HyperPosition hyperPosition){
        switch(hyperDirection.unSeen){
            case Direction.left:
            case Direction.right:
            return new GridSlice(WorldOrientation.xyz, hyperPosition.w);

            case Direction.north:
            case Direction.south:
            return new GridSlice(WorldOrientation.xyw, hyperPosition.z);

            case Direction.east:
            case Direction.west:
            return new GridSlice(WorldOrientation.yzw, hyperPosition.x);

            case Direction.up:
            case Direction.down:
            return new GridSlice(WorldOrientation.xzw, hyperPosition.y);
        }
        return new GridSlice(WorldOrientation.xyz, hyperPosition.w);
    }
}
