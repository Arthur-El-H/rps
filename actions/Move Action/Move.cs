using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Move: IAction
{
    Player _player;
    public List<Tile> _goals;

    public Move(Player player)
    {
        _player = player;
        _goals = new List<Tile>();
    }

    public async Task act()
    {
        foreach (Tile tile in _goals)
        {
            await _player.moveTo(tile);
        }
    }
}
