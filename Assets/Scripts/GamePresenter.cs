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
        gridPresenter.createGrid();
    }

    void Update() {

    }
}
