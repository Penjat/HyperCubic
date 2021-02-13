using System.Collections;
using System.Collections.Generic;

public class LevelDatabase {
    public Level[] levels { get; private set; } =
        new Level[]{
            LEVEL_1,
            LEVEL_2,
            LEVEL_3};

    private static Level LEVEL_1 = new Level(HyperGrid.ConstructedLevel(),new HyperPosition(2,3,2,0), new HyperPosition(2,3,6,0));
    private static Level LEVEL_2 = new Level(HyperGrid.TenByTenCube(),new HyperPosition(1,3,2,0), new HyperPosition(2,3,6,0));
    private static Level LEVEL_3 = new Level(HyperGrid.TenByTenPyramid(),new HyperPosition(2,3,2,0), new HyperPosition(2,3,6,0));
}
