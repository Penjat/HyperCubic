using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveResult {
    forward, downward, upward
}

public class GridManager {

    public MoveResult moveResult(bool frontBlocked, bool belowBlocked) {
        if (frontBlocked) {
            return MoveResult.upward;
        } else if (belowBlocked) {
            return MoveResult.forward;
        }
        return MoveResult.downward;
    }
}
