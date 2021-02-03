using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPresenter : MonoBehaviour {
    public GameObject blockPrefab;
    public void createGrid() {
        GameObject block = Instantiate(blockPrefab);
    }
}
