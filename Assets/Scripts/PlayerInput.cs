using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public void pressedForward() {
        Debug.Log("pressed FORWARD.");
    }

    public void pressedTurnLeft() {
        Debug.Log("pressed TURN LEFT.");
    }

    public void pressedTurnRight() {
        Debug.Log("pressed TURN RIGHT.");
    }

    public void pressedTurnUnseenLeft() {
        Debug.Log("pressed UNSEEN LEFT.");
    }

    public void pressedTurnUnseenRight() {
        Debug.Log("pressed UNSEEN RIGHT.");
    }
}
