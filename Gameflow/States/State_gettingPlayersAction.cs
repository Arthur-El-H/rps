using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingPlayersAction: IState
{
    State_gettingPlayersTurn _stateToReturnTo;
    IActionCapability _actionCapability;
    IAction _action;
    statemachine _statemachine;
    Player _player;

    public State_gettingPlayersAction(statemachine statemachine, Player player, State_gettingPlayersTurn stateToReturnTo, IActionCapability actionCapability)
    {
        _actionCapability = actionCapability;
        _statemachine = statemachine;
        _stateToReturnTo = stateToReturnTo;
        _player = player;
    }

    public void init()
    {
    }

    public void Execute()
    {        
    }

    public void Exit()
    {        
    }

    public void handleInput(IInput input)
    {
        _actionCapability.handleInput(input);
    }

    internal void finishAction()
    {
        _stateToReturnTo.addPlayersAction(_action);
    }
}