using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperGrid {
    byte[,,,] grid;
    public HyperGrid (int xSize, int ySize, int zSize, int wSize) {
        grid = new byte[xSize, ySize, zSize, wSize];
    }

    public bool checkBlocked(HyperPosition position) {
        return checkBlocked(position.x, position.y, position.z, position.w);
    }

    public bool checkBlocked(int x, int y, int z, int w) {
        return grid[x, y, z, w] != 0;
    }

    public void setBlocked(int x, int y, int z, int w) {
        grid[x, y, z, w] = 1;
    }
}
