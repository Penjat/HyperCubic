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
    private List<PiecePresenter> gamePieces = new List<PiecePresenter>();

    public void addPiece(PiecePresenter piece) {
        gamePieces.Add(piece);
    }

    public void UpdateShownPieces(GridSlice gridSlice) {
        foreach(PiecePresenter piece in gamePieces) {
            placeItemFor(piece, gridSlice);
        }
    }

    private void createGrid() {
        blocks = new GameObject[Constants.sizeX,Constants.sizeY,Constants.sizeZ];
        for(int x=0;x<Constants.sizeX;x++){
            for(int y=0;y<Constants.sizeY;y++){
                for(int z=0;z<Constants.sizeZ;z++){
                GameObject block = Instantiate(blockPrefab) as GameObject;
                block.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
                blocks[x,y,z] = block;
                }
            }
        }
    }

    public void updateGrid(HyperGrid hyperGrid, GridSlice slice){
        if(blocks == null) {
            createGrid();
        }
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

    public void placeItemFor(PiecePresenter piece, GridSlice gridSlice) {
        switch(gridSlice.worldOrientation){
            case WorldOrientation.xyz:
            if(piece.hyperPosition.w != gridSlice.unseenDepth){
                piece.SetSeen(false);
                return;
            }
            piece.SetSeen(true);
            placeSomething(piece.gameObject, piece.hyperPosition.x, piece.hyperPosition.y, piece.hyperPosition.z);
            break;

            case WorldOrientation.xyw:
            if(piece.hyperPosition.z != gridSlice.unseenDepth){
                piece.SetSeen(false);
                return;
            }
            piece.SetSeen(true);
            placeSomething(piece.gameObject, piece.hyperPosition.x, piece.hyperPosition.y, piece.hyperPosition.w);
            break;

            case WorldOrientation.xzw:
            if(piece.hyperPosition.y != gridSlice.unseenDepth){
                piece.SetSeen(false);
                return;
            }
            piece.SetSeen(true);
            placeSomething(piece.gameObject, piece.hyperPosition.x, piece.hyperPosition.w, piece.hyperPosition.z);
            break;

            case WorldOrientation.yzw:
            if(piece.hyperPosition.x != gridSlice.unseenDepth){
                piece.SetSeen(false);
                return;
            }
            piece.SetSeen(true);
            placeSomething(piece.gameObject, piece.hyperPosition.w, piece.hyperPosition.y, piece.hyperPosition.z);
            break;
        }
    }
    public void placeSomething(GameObject item, int x, int y, int z) {
        item.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
    }
}
