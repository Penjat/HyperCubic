using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public Camera backgroundCamera;

    public Color xyzColor;
    public Color wyzColor;
    public Color xwzColor;
    public Color xywColor;

    private bool isChanging;
    private float timer = 0.0f;
    private Color oldColor;
    private Color newColor;

    private struct Constants {
        public static float changeDuration = 1.0f;
    }

    public void setBackgroundForOrientation(WorldOrientation worldOrientation) {
        timer = 1.0f;
        isChanging = true;
        switch(worldOrientation){
            case WorldOrientation.xyz:
            newColor = xyzColor;
            break;

            case WorldOrientation.xyw:
            newColor = xywColor;
            break;

            case WorldOrientation.yzw:
            newColor = wyzColor;
            break;

            case WorldOrientation.xzw:
            newColor = xwzColor;
            break;
        }
    }

    void Update() {
        if(isChanging){
            timer -= Time.deltaTime/Constants.changeDuration;
            Color lerpedColor = Color.Lerp(newColor, oldColor, timer);
            backgroundCamera.backgroundColor = lerpedColor;

            if(timer <= 0.0f){
                isChanging = false;
                timer = 0.0f;
                oldColor = newColor;
            }
        }
    }
}
