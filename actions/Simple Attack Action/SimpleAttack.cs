
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimpleAttack : IAction
{
    Player _player;
    public Tile _target;
    int damage = 4;

    public SimpleAttack(Player player)
    {
        _player = player;
    }
    public async Task act()
    {
        if (!_target._isPlayerOnTile()) return;
        _target._playersOnTile[0].getHit(damage);
    }

    public int halfToStartAt()
    {
        return Turn.startingInSecondHalf;
    }
}
