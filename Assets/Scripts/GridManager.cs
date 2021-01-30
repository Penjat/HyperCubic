using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveResut {
    forward, downward, upward
}

public class GridManager {

    public MoveResut moveResult() {
        bool isFrontBlock = true;
        bool isBelowBlock = true;

        if (isFrontBlock) {
            return MoveResut.upward;
        } else if (isBelowBlock) {
            return MoveResut.forward;
        }
        return MoveResut.downward;
    }
}
