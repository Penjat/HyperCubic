using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour {
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
}
