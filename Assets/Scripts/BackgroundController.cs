using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public Camera backgroundCamera;

    public void setBackgroundForOrientation(WorldOrientation worldOrientation) {
        switch(worldOrientation){
            case WorldOrientation.xyz:
            backgroundCamera.backgroundColor = Color.blue;
            break;
            case WorldOrientation.xyw:
            backgroundCamera.backgroundColor = Color.green;
            break;
            case WorldOrientation.yzw:
            backgroundCamera.backgroundColor = Color.red;
            break;
            case WorldOrientation.xzw:
            backgroundCamera.backgroundColor = Color.yellow;
            break;
        }
    }
    void Update() {

    }
}
