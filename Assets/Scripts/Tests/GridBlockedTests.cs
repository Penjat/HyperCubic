using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridBlockedTests {
    [Test]
    public void TestEmptyGridIsNotBlocked() {
        HyperGrid hyperGrid = new HyperGrid(5,5,5,5);
        bool isBlocked1 = hyperGrid.checkBlocked(0,0,0,0);
        bool isBlocked2 = hyperGrid.checkBlocked(0,0,2,2);
        bool isBlocked3 = hyperGrid.checkBlocked(0,3,1,0);
        bool isBlocked4 = hyperGrid.checkBlocked(2,3,3,3);

        Assert.IsFalse(isBlocked1);
        Assert.IsFalse(isBlocked2);
        Assert.IsFalse(isBlocked3);
        Assert.IsFalse(isBlocked4);
    }

    [Test]
    public void TestFullGridIsBlocked() {
        HyperGrid hyperGrid = new HyperGrid(5,5,5,5);

        for(int x=0;x<5;x++) {
            for(int y=0;y<5;y++) {
                for(int z=0;z<5;z++) {
                    for(int w=0;w<5;w++) {
                        hyperGrid.setBlocked(x,y,z,w);
                    }
                }
            }
        }

        bool isBlocked1 = hyperGrid.checkBlocked(0,2,0,0);
        bool isBlocked2 = hyperGrid.checkBlocked(0,0,2,2);
        bool isBlocked3 = hyperGrid.checkBlocked(0,3,1,0);
        bool isBlocked4 = hyperGrid.checkBlocked(2,1,3,3);

        Assert.IsTrue(isBlocked1);
        Assert.IsTrue(isBlocked2);
        Assert.IsTrue(isBlocked3);
        Assert.IsTrue(isBlocked4);
    }

    [Test]
    public void TestSomeBlockedOthersNot() {
        //Given
        HyperGrid hyperGrid = new HyperGrid(8,8,8,8);

        //When
        hyperGrid.setBlocked(0,0,0,0);
        hyperGrid.setBlocked(3,3,2,1);
        hyperGrid.setBlocked(7,6,5,4);
        hyperGrid.setBlocked(3,0,2,7);

        //Then
        Assert.IsTrue(hyperGrid.checkBlocked(0,0,0,0));
        Assert.IsFalse(hyperGrid.checkBlocked(0,0,0,1));
        Assert.IsTrue(hyperGrid.checkBlocked(3,3,2,1));
        Assert.IsFalse(hyperGrid.checkBlocked(7,7,7,7));
        Assert.IsTrue(hyperGrid.checkBlocked(7,6,5,4));
        Assert.IsTrue(hyperGrid.checkBlocked(3,0,2,7));
    }
}
