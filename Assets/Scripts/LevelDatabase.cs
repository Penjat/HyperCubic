using System.Collections;
using System.Collections.Generic;

public class LevelDatabase {
    public Level getLevel() {
        return new Level(HyperGrid.ConstructedLevel());
    }
}
