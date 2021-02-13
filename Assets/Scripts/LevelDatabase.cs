using System.Collections;
using System.Collections.Generic;

public class LevelDatabase {
    public Level[] levels { get; private set; } =
        new Level[]{
            new Level(HyperGrid.ConstructedLevel()),
            new Level(HyperGrid.TenByTenPyramid()),
            new Level(HyperGrid.TenByTenCube())};
}
