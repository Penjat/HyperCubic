using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonInput {
    forward, left, right, unseenLeft, unseenRight
}

public class PlayerInput : MonoBehaviour {
    public GameObject output;
    private IPlayerInputReciever inputReciever;

    void Start() {
        inputReciever = output.GetComponent<IPlayerInputReciever>();
    }

    public void pressedForward() {
        Debug.Log("pressed FORWARD.");
        inputReciever.process(ButtonInput.forward);
    }

    public void pressedTurnLeft() {
        Debug.Log("pressed TURN LEFT.");
        inputReciever.process(ButtonInput.left);
    }

    public void pressedTurnRight() {
        Debug.Log("pressed TURN RIGHT.");
        inputReciever.process(ButtonInput.right);
    }

    public void pressedTurnUnseenLeft() {
        Debug.Log("pressed UNSEEN LEFT.");
        inputReciever.process(ButtonInput.unseenLeft);
    }

    public void pressedTurnUnseenRight() {
        Debug.Log("pressed UNSEEN RIGHT.");
        inputReciever.process(ButtonInput.unseenRight);
    }
}

public interface IPlayerInputReciever {
    void process(ButtonInput input);
}
