using System.Collections;
using System.Collections.Generic;

public struct Level {
    public HyperGrid hyperGrid;
    public HyperPosition playerStart;
    public HyperPosition goalPosition;
    public Level(HyperGrid hyperGrid, HyperPosition playerStart, HyperPosition goalPosition) {
        this.hyperGrid = hyperGrid;
        this.playerStart = playerStart;
        this.goalPosition = goalPosition;
    }
}
