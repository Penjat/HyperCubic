using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePresenter : MonoBehaviour {
    public HyperPosition hyperPosition;
    public void SetSeen(bool isSeen) {
        gameObject.SetActive(isSeen);
    }
}
