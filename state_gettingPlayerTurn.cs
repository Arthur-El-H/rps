using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingPlayersTurn : IState
{
    int _amountOfActionsAllowed; //get from player
    int _amountOfActions; //get from player
    public Player _player;
    public statemachine _statemachine;

    public Queue<actionBase> _actionsOfPlayer;
    List<actionCapabilityBase> _displayedActionCapabilities;

    public State_gettingPlayersTurn(statemachine statemachine, Player player, Queue<actionBase> actionsOfPlayer)
    {
        _statemachine = statemachine;
        if (actionsOfPlayer == null)
        {
            _actionsOfPlayer = new Queue<actionBase>();
        }
        else
        {
            _actionsOfPlayer = actionsOfPlayer;
        }
        _player = player;
        //TODO get amountOfAction und amountOfActionALlowed
    }

    public void Enter()
    {
        _player.displayPossibleActions();
    }

    public void Execute()
    {
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
                State_gettingPlayersAction state_gettingAction = new State_gettingPlayersAction(_statemachine, _actionsOfPlayer, _player);
                _statemachine.changeState(state_gettingAction);
                break;



            default:
                break;
        }
    }
}
