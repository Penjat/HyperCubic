using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePresenter : MonoBehaviour, IPlayerInputReciever {
    private Game game;
    private Player player;
    private HyperGrid hyperGrid;

    public GridPresenter gridPresenter;
    public PlayerPresenter playerPresenter;
    public GoalPresenter goalPresenter;

    public Text worldOrientationText;

    void Start() {
        HyperPosition startPosition = new HyperPosition(2,3,2,0);
        player = new Player(startPosition, HyperDirection.normal);
        hyperGrid = HyperGrid.TenByTenPyramid();
        goalPresenter.hyperPosition = new HyperPosition(6,3,2,0);
        gridPresenter.addPiece(goalPresenter);
        game = new Game(player, hyperGrid,goalPresenter.hyperPosition);

        gridPresenter.createGrid(hyperGrid, playerPresenter.orientationForDirection(player.direction, player.position));
        gridPresenter.placeSomething(playerPresenter.gameObject,player.position.x,player.position.y,player.position.z);
        gridPresenter.UpdateShownPieces(playerPresenter.orientationForDirection(player.direction, player.position));

        GridSlice gridSlice = playerPresenter.orientationForDirection(player.direction, player.position);
        worldOrientationText.text = stringForOrientation(gridSlice.worldOrientation);
    }

    public void process(ButtonInput input) {
        GridSlice gridSlice;
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
                gridSlice = playerPresenter.orientationForDirection(player.direction, player.position);
                worldOrientationText.text = stringForOrientation(gridSlice.worldOrientation);
                gridPresenter.changeOrientation(hyperGrid, gridSlice);
                break;
            case ButtonInput.unseenRight:
                game.process(MoveIntent.turnRightUnseen);
                gridSlice = playerPresenter.orientationForDirection(player.direction, player.position);
                worldOrientationText.text = stringForOrientation(gridSlice.worldOrientation);
                gridPresenter.changeOrientation(hyperGrid, gridSlice);
                break;
        }
        //TODO: fix how this is Connected
        playerPresenter.hyperPosition = player.position;
        gridPresenter.placeItemFor(playerPresenter,playerPresenter.orientationForDirection(player.direction, player.position));
        gridPresenter.UpdateShownPieces(playerPresenter.orientationForDirection(player.direction, player.position));
        if(game.checkWon()){
            Debug.Log("You Won!!!!");
        }
        //TODO: make this work again
        // playerPresenter.rotateToFace(player.direction);
    }

    public string stringForOrientation(WorldOrientation worldOrientation) {
        switch (worldOrientation) {
            case WorldOrientation.xyz:
            return "X Y Z";
            case WorldOrientation.yzw:
            return "W Y Z";
            case WorldOrientation.xyw:
            return "X Y W";
            case WorldOrientation.xzw:
            return "X W Z";
        }
        return "-";
    }
}
