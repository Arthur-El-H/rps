using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingPlayersTurn : IState
{
    State_gettingAllPlayersTurns _stateToReturnTo;
    public Player _player;
    public statemachine _statemachine;

    public Queue<ActionBase> _actionsOfPlayer;
    List<actionCapabilityBase> _displayedActionCapabilities;

    public State_gettingPlayersTurn(statemachine statemachine, Player player, State_gettingAllPlayersTurns stateToReturnTo)
    {
        _statemachine = statemachine;
        _stateToReturnTo = stateToReturnTo;
        _player = player;
        //TODO get amountOfAction und amountOfActionALlowed
    }

    public void addPlayersAction(ActionBase action)
    {
        _actionsOfPlayer.Enqueue(action);
        if (isActionQueueFull(_actionsOfPlayer))
        {
            _stateToReturnTo.addPlayersTurnToCompleteTurn(_actionsOfPlayer);
        }
        else
        {
            _statemachine.changeState(this);
        }
    }
    private bool isActionQueueFull(Queue<ActionBase> _actionsOfPlayer)
    {
        return (_player.maxActionsPerTurn <= _actionsOfPlayer.Count);
    }

    public void Enter()
    {
        _player.displayPossibleActions();
    }

    public void Execute()
    {
        //At end
        _stateToReturnTo.addPlayersTurnToCompleteTurn(_actionsOfPlayer);
    }

    public void Exit()
    {
        _player.undisplayPossibleActions();
    }

    public void handleInput( IInput input)
    {
        char inputType = input.getInputType();
        switch (inputType)
        {
            case InputManager.actionClickedType:
                ActionInput actionInput = input as ActionInput;
                State_gettingPlayersAction state_gettingAction = new State_gettingPlayersAction(_statemachine, _player, this);
                _statemachine.changeState(state_gettingAction);
                break;


            default:
                break;
        }
    }
}

