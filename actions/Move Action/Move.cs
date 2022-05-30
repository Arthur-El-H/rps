using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Move: IAction
{
    Player _player;
    public List<Tile> _goals;

    public void unmarkTiles()
    {
        foreach (Tile tile in _goals)
        {
            tile.demark();
        }
    }

    public Move(Player player)
    {
        _player = player;
        _goals = new List<Tile>();
    }

    public async Task act()
    {
        await _player.moveTo(_goals[0]);
    }
}
