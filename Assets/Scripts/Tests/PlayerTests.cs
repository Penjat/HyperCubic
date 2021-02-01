using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests {
    [Test]
    public void CreatePlayerWithPosition() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);
        HyperPosition pos = new HyperPosition(0,5,0,4);
        Player player = new Player(pos, dir);

        Assert.AreEqual(player.position.x, 0);
        Assert.AreEqual(player.position.y, 5);
        Assert.AreEqual(player.position.z, 0);
        Assert.AreEqual(player.position.w, 4);

        Assert.AreEqual(player.direction.facing, Direction.east);
        Assert.AreEqual(player.direction.standing, Direction.up);
        Assert.AreEqual(player.direction.toSide, Direction.north);
        Assert.AreEqual(player.direction.unSeen, Direction.left);
    }

    public void MovePlayerForward() {
        HyperDirection dir = new HyperDirection(Direction.east, Direction.up, Direction.north, Direction.left);
        HyperPosition pos = new HyperPosition(6,2,1,1);
        Player player = new Player(pos, dir);

        Assert.AreEqual(player.position.x, 6);
        Assert.AreEqual(player.position.y, 2);
        Assert.AreEqual(player.position.z, 1);
        Assert.AreEqual(player.position.w, 1);


    }
}
