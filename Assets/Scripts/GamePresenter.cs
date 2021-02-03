using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour {
    private Game game;
    private Player player;
    private HyperGrid hyperGrid;
    public GridPresenter gridPresenter;

    void Start() {
        Debug.Log("Starting up.");
        hyperGrid = new HyperGrid(10,10,10,10);
        gridPresenter.createGrid(hyperGrid);
    }

    void Update() {

    }
}
