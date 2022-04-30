using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingPlayersAction: IState
{
    State_gettingPlayersTurn _stateToReturnTo;
    ActionBase _action;
    statemachine _statemachine;
    Player _player;

    public State_gettingPlayersAction(statemachine statemachine, Player player, State_gettingPlayersTurn stateToReturnTo)
    {
        _statemachine = statemachine;
        _stateToReturnTo = stateToReturnTo;
        _player = player;
    }

    public void Enter()
    {
    }

    public void Execute()
    {
        //At the end:
        _stateToReturnTo.addPlayersAction(_action);
    }

    public void Exit()
    {
    }

    public void handleInput(IInput input)
    {
        throw new System.NotImplementedException();
    }
}