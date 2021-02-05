using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPresenter : MonoBehaviour {
    private struct Constants {
        public static float gridSpacing = 1.01f;
    }

    public GameObject blockPrefab;

    public void createGrid(HyperGrid hyperGrid, GridSlice slice) {
        for(int x=0;x<10;x++){
            for(int y=0;y<10;y++){
                for(int z=0;z<10;z++){
                GameObject block = Instantiate(blockPrefab) as GameObject;
                block.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
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
            return hyperGrid.checkBlocked(y,z,w,x);
            case WorldOrientation.xzw:
            return hyperGrid.checkBlocked(x,z,w,y);
        }
        return false;
    }
    public void placeSomething(GameObject item, int x, int y, int z) {
        item.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
    }
}
