using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPresenter : MonoBehaviour {
    private struct Constants {
        public static float gridSpacing = 1.01f;
        public static int sizeX = 10;
        public static int sizeY = 10;
        public static int sizeZ = 10;
    }

    public GameObject blockPrefab;
    public GameObject[,,] blocks;
    private List<Piece> gamePieces = new List<Piece>();

    public void addPiece(Piece piece) {
        gamePieces.Add(piece);
    }

    public void UpdateShownPieces(GridSlice gridSlice) {
        foreach(Piece piece in gamePieces) {
            placeItemFor(piece.gameObject, piece.hyperPosition, gridSlice);
        }
    }

    public void createGrid(HyperGrid hyperGrid, GridSlice slice) {
        blocks = new GameObject[10,10,10];
        for(int x=0;x<Constants.sizeX;x++){
            for(int y=0;y<Constants.sizeY;y++){
                for(int z=0;z<Constants.sizeZ;z++){
                GameObject block = Instantiate(blockPrefab) as GameObject;
                block.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
                block.SetActive(checkBlockedForDirection(hyperGrid,slice.worldOrientation,x,y,z,slice.unseenDepth));
                blocks[x,y,z] = block;
                }
            }
        }
    }

    public void changeOrientation(HyperGrid hyperGrid, GridSlice slice){
        print("is time to change orientation.");
        for(int x=0;x<Constants.sizeX;x++){
            for(int y=0;y<Constants.sizeY;y++){
                for(int z=0;z<Constants.sizeZ;z++){
                    GameObject block = blocks[x,y,z];
                    block.SetActive(checkBlockedForDirection(hyperGrid,slice.worldOrientation,x,y,z,slice.unseenDepth));
                }
            }
        }
    }

    private bool checkBlockedForDirection(HyperGrid hyperGrid, WorldOrientation dir, int x, int y, int z, int w) {
        switch (dir) {
            case WorldOrientation.xyz:
            return hyperGrid.checkBlocked(x,y,z,w);
            case WorldOrientation.xyw:
            return hyperGrid.checkBlocked(x,y,w,z);
            case WorldOrientation.yzw:
            return hyperGrid.checkBlocked(w,y,z,x);
            case WorldOrientation.xzw:
            return hyperGrid.checkBlocked(x,w,z,y);
        }
        return false;
    }

    public void placeItemFor(GameObject item, HyperPosition hyperPosition, GridSlice gridSlice) {
        switch(gridSlice.worldOrientation){
            case WorldOrientation.xyz:
                placeSomething(item, hyperPosition.x, hyperPosition.y, hyperPosition.z);
                break;
            case WorldOrientation.xyw:
                placeSomething(item, hyperPosition.x, hyperPosition.y, hyperPosition.w);
                break;
            case WorldOrientation.xzw:
                placeSomething(item, hyperPosition.x, hyperPosition.w, hyperPosition.z);
                break;
            case WorldOrientation.yzw:
                placeSomething(item, hyperPosition.w, hyperPosition.y, hyperPosition.z);
                break;
        }
    }
    public void placeSomething(GameObject item, int x, int y, int z) {
        item.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
    }
}
