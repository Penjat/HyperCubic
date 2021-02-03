using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPresenter : MonoBehaviour {
    private struct Constants {
        public static float gridSpacing = 1.2f;
    }

    public GameObject blockPrefab;

    public void createGrid() {
        for(int x=0;x<10;x++){
            for(int y=0;y<10;y++){
                for(int z=0;z<10;z++){
                GameObject block = Instantiate(blockPrefab);
                blockPrefab.transform.position = new Vector3(x*Constants.gridSpacing,y*Constants.gridSpacing,z*Constants.gridSpacing);
                }
            }
        }
    }
}
