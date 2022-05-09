using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionBuilder : IActionBuilder
{
    Player _player;
    Act_Move _actToBuild;
    InputManager _inputManager;

    public MoveActionBuilder(Player player)
    {
        _player = player;
        _actToBuild = new Act_Move(_player);
    }

    public IAction getAction()
    {
        return _actToBuild;
    }

    public void handleInput(IInput input)
    {
        if (input.getInputType() == TileInput._type)
        {
            handleTileInput(input);
        }

        if (input.getInputType() == ConfirmInput._type)
        {
            handleConfirmInput();
        }
    }

    private void handleConfirmInput()
    {
        if (_actToBuild._goals.Count == 0)
        {
            throw new NoGoalsException();
        }
        else
        {
            //_actToBuild.finishAction();
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
