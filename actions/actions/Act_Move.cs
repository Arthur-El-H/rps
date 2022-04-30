using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Act_Move: ActionBase
{
    Player _player;
    List<Tile> _goals;

    public Act_Move(Player player, List<Tile> goals)
    {
        _player = player;
        _goals = goals;
    }

    public async override Task Act()
    {
        foreach (Tile tile in _goals)
        {
            await _player.moveTo(tile);
        }
    }
}
