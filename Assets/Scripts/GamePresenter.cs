using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour, IPlayerInputReciever {
    private Game game;
    private Player player;
    private HyperGrid hyperGrid;

    public GridPresenter gridPresenter;
    public PlayerPresenter playerPresenter;

    void Start() {
        Debug.Log("Starting up.");
        hyperGrid = HyperGrid.TenByTenPlatformAtWZero();
        gridPresenter.createGrid(hyperGrid, new GridSlice(WorldOrientation.xyz,0));
        gridPresenter.placeSomething(playerPresenter.gameObject,3,3,3);
    }

    public void process(ButtonInput input) {
        Debug.Log("Delegate recieved input.");
        switch(input) {
            case ButtonInput.forward:
                break;
            case ButtonInput.left:
                break;
            case ButtonInput.right:
                break;
            case ButtonInput.unseenLeft:
                break;
            case ButtonInput.unseenRight:
                break;
        }
    }
}
