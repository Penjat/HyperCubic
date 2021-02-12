using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HyperGridCreationTests {
    // A Test behaves as an ordinary method
    [Test]
    public void HyperGridCreationTestsSimplePasses() {
        HyperGrid hyperGrid = new HyperGrid(10,10,10,10);

        hyperGrid.createPath(new HyperPosition(0,0,0,0),Direction.east,7);

        Assert.IsTrue(hyperGrid.checkBlocked(0,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(1,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(2,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(3,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(4,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(5,0,0,0));
        Assert.IsTrue(hyperGrid.checkBlocked(6,0,0,0));
        Assert.IsFalse(hyperGrid.checkBlocked(7,0,0,0));

        Assert.IsFalse(hyperGrid.checkBlocked(8,0,0,0));
        Assert.IsFalse(hyperGrid.checkBlocked(0,1,0,0));
        Assert.IsFalse(hyperGrid.checkBlocked(0,0,1,0));
    }
}
