using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack_Builder : IActionBuilder
{
    Player _player;
    SimpleAttack _actToBuild;
    public SimpleAttack_Builder(Player player)
    {
        _player = player;
        _actToBuild = new SimpleAttack(_player);
    }

    public IAction getAction()
    {
        InputManager.unsubscribeToTileClicked(handleTileInput);
        _actToBuild._target.demark();
        return _actToBuild;
    }

    public void init()
    {
        InputManager.subscribeToTileClicked(handleTileInput);
    }

    public void validateActionFinished()
    {
        if (_actToBuild._target == null)
        {
            throw new ActionNotFinishedException();
        }
    }

    private void handleTileInput(IInput input)
    {
        // TODO: Order of goals! Or only one goal
        Tile selectedTile = (input as TileInput)._selectedTile;
        if (!selectedTile.isAdjacentTo(_player._currentTile))
        {
            Debug.Log("Tile needs to be adjacent");
        }
        _actToBuild._target?.demark();
        _actToBuild._target = selectedTile;
        selectedTile.mark();
    }
}
