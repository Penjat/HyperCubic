using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {
    private Game game;
    private Player player;
    private HyperGrid hyperGrid;

    public GridPresenter gridPresenter;
    public PlayerPresenter playerPresenter;

    void Start() {
        Debug.Log("Starting up.");
        hyperGrid = HyperGrid.TenByTenPlatformAtWZero();
        gridPresenter.createGrid(hyperGrid, new GridSlice(WorldOrientation.xyz,0));
    }

    void Update() {

    }
}
