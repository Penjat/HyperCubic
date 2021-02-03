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
        if(x >= grid.GetLength(0) || y >= grid.GetLength(1) || z >= grid.GetLength(2) || w >= grid.GetLength(3)){
            return false;
        }

        if(x < 0 || y < 0 || z < 0 || w < 0) {
            return false;
        }

        return grid[x, y, z, w] != 0;
    }

    public void setBlocked(int x, int y, int z, int w) {
        grid[x, y, z, w] = 1;
    }
}
