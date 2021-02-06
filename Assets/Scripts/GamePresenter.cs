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


        HyperPosition startPosition = new HyperPosition(2,3,2,0);
        player = new Player(startPosition, HyperDirection.normal);
        hyperGrid = HyperGrid.TenByTenPyramid();
        game = new Game(player, hyperGrid);

        gridPresenter.createGrid(hyperGrid, new GridSlice(WorldOrientation.xyz,0));
        gridPresenter.placeSomething(playerPresenter.gameObject,player.position.x,player.position.y,player.position.z);
    }

    public void process(ButtonInput input) {
        Debug.Log("Delegate recieved input.");
        switch(input) {
            case ButtonInput.forward:
                game.process(MoveIntent.forward);
                break;
            case ButtonInput.left:
                game.process(MoveIntent.turnLeftSide);
                break;
            case ButtonInput.right:
                game.process(MoveIntent.turnRightSide);
                break;
            case ButtonInput.unseenLeft:
                game.process(MoveIntent.turnLeftUnseen);
                break;
            case ButtonInput.unseenRight:
                game.process(MoveIntent.turnRightUnseen);
                break;
        }
        gridPresenter.placeSomething(playerPresenter.gameObject,player.position.x,player.position.y,player.position.z);
        playerPresenter.rotateToFace(player.direction);
    }
}
