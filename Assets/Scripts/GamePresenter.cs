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
        HyperPosition startPosition = new HyperPosition(2,3,2,0);
        player = new Player(startPosition, HyperDirection.normal);
        hyperGrid = HyperGrid.TenByTenPyramid();
        game = new Game(player, hyperGrid);


        gridPresenter.createGrid(hyperGrid, playerPresenter.orientationForDirection(player.direction, player.position));
        gridPresenter.placeSomething(playerPresenter.gameObject,player.position.x,player.position.y,player.position.z);
    }

    public void process(ButtonInput input) {
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
                gridPresenter.changeOrientation(hyperGrid, playerPresenter.orientationForDirection(player.direction, player.position));
                break;
            case ButtonInput.unseenRight:
                game.process(MoveIntent.turnRightUnseen);
                gridPresenter.changeOrientation(hyperGrid, playerPresenter.orientationForDirection(player.direction, player.position));
                break;
        }
        gridPresenter.placeItemFor(playerPresenter.gameObject,player.position,playerPresenter.orientationForDirection(player.direction, player.position).worldOrientation);
        // playerPresenter.rotateToFace(player.direction);
    }
}
