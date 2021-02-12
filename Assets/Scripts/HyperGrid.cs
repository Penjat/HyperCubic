using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperGrid {
    byte[,,,] grid;

    public HyperGrid(int xSize, int ySize, int zSize, int wSize) {
        grid = new byte[xSize, ySize, zSize, wSize];
    }

    public HyperGrid(byte[,,,] grid) {
        this.grid = grid;
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

    //--------------------Methods for step by step grid creation---------
    public void createPath(HyperPosition startPosition, Direction direction, int amount) {
        //Creates a path from one point to another
        int x = startPosition.x;
        int y = startPosition.y;
        int z = startPosition.z;
        int w = startPosition.w;
        for(int i=0;i<amount;i++) {
            setBlocked(x+i,y,z,w);
        }
    }

    //---------------------Easy Grid Creation, to be removed--------------
    public static HyperGrid ConstructedLevel(){
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        hyperGrid.createPath(new HyperPosition(2,2,2,0),Direction.east,6);
        return hyperGrid;
    }
    public static HyperGrid TenByTenPlatformAtWZero() {
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        for(int x=2;x<8;x++){
            for(int z=2;z<8;z++){
                hyperGrid.setBlocked(x,2,z,0);
            }
        }
        return hyperGrid;
    }

    public static HyperGrid TenByTenCube() {
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        for(int x=2;x<8;x++){
            for(int z=2;z<8;z++){
                for(int y=2;y<8;y++){
                    hyperGrid.setBlocked(x,y,z,0);
                }
            }
        }
        return hyperGrid;
    }

    public static HyperGrid TenByTenPyramid() {
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);
        int baseStart = 2;
        int baseEnd = 8;
        for(int y=2;y<8;y++){
            for(int x=baseStart;x<baseEnd;x++){
                for(int z=baseStart;z<baseEnd;z++){

                    hyperGrid.setBlocked(x,y,z,0);
                }
            }
            baseStart++;
            baseEnd--;
        }
        return hyperGrid;
    }
}
