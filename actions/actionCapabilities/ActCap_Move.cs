using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActCap_Move : IActionCapability
{
    Player player;
    Act_Move _actToBuild;
    GameObject _actionDisplay;
    GameObject _pref_actionDisplay;
    statemachine _statemachine;
    State_gettingPlayersAction _buildingState;
    Canvas _canvas;

    public ActCap_Move()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _pref_actionDisplay = Prefabs.Instance.prefab_ActMoveDisplay;
    }

    public IAction getAction()
    {
        throw new System.NotImplementedException();
    }

    public GameObject getActionDisplayObject()
    {
        GameObject _actionDisplay = GameObject.Instantiate(_pref_actionDisplay,_canvas.transform);
        return _actionDisplay;
    }


    public void handleInput(IInput input)
    {
        if (input.getInputType() == TileInput._type)
        {
            TileInput tileInput = input as TileInput;
            Tile tileGoal = tileInput._goalTile;
            if (_actToBuild._goals.Contains(tileGoal))
            {
                tileGoal.demark();
                _actToBuild._goals.Remove(tileGoal);
            }
            else
            {
                tileGoal.mark();
                _actToBuild._goals.Add(tileGoal);
            }
        }

        if (input.getInputType() == ConfirmInput._type)
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
    }
}

