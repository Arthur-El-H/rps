using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Builder : IActionBuilder
{
    Player _player;
    Move _actToBuild;

    public Move_Builder(Player player)
    {
        _player = player;
        _actToBuild = new Move(_player);
    }

    public IAction getAction()
    {
        InputManager.unsubscribeToTileClicked(handleTileInput);
        _actToBuild.unmarkTiles();
        return _actToBuild;
    }

    public void init()
    {
        InputManager.subscribeToTileClicked(handleTileInput);
    }

    public void validateActionFinished()
    {
        if (_actToBuild._goals.Count == 0)
        {
            throw new ActionNotFinishedException();
        }
    }

    private void handleTileInput(IInput input)
    {
        // TODO: Order of goals! Or only one goal
        Tile selectedTile = (input as TileInput)._selectedTile;
        if (_actToBuild._goals.Contains(selectedTile))
        {
            selectedTile.demark();
            _actToBuild._goals.Remove(selectedTile);
        }
        else
        {
            selectedTile.mark();
            _actToBuild._goals.Add(selectedTile);
        }
    }
}
