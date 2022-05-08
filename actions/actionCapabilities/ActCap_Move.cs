using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActCap_Move : IActionCapability
{
    Player _player;
    Act_Move _actToBuild;
    GameObject _moveBtn;
    GameObject _pref_actionDisplay;
    Canvas _canvas;

    public ActCap_Move(Player player)
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _pref_actionDisplay = Prefabs.Instance.prefab_ActMoveDisplay;
        _player = player;
        _actToBuild = new Act_Move(_player);
    }

    public IAction getAction()
    {
        return _actToBuild;
    }

    public GameObject getActionDisplayObject()
    {
        _moveBtn = GameObject.Instantiate(_pref_actionDisplay,_canvas.transform);
        return _moveBtn;
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
            _buildingState.finishAction();
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

