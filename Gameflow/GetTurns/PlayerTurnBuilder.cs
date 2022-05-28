using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBuilder 
{
    TurnBuilder _turnBuilder;
    Vector2 _testPlaceOfCap = new Vector2(-7, 3);
    public Player _player;
    private IActionBuilder _currentActionBuilder;

    public Queue<IAction> _playerTurn;

    public PlayerTurnBuilder(TurnBuilder turnBuilder, Player player)
    {
        _turnBuilder = turnBuilder;
        _player = player;
        //TODO get amountOfAction und amountOfActionALlowed
    }
    public void init()
    {
        _player.displayPossibleActions();
        subscribeToActionInput();
    }

    //On Finish of child
    public void addPlayerActionToPlayerTurn(IAction action)
    {
        _playerTurn.Enqueue(action);
        if (isActionQueueFull(_playerTurn))
        {
            _turnBuilder.addPlayersTurn(_playerTurn);
        }
        else
        {
            initPlayerActionBuilding();
        }
    }
    private bool isActionQueueFull(Queue<IAction> _actionsOfPlayer)
    {
        return (_player._maxActionsPerTurn <= _actionsOfPlayer.Count);
    }
    private void initPlayerActionBuilding()
    {
        _player.displayPossibleActions();
    }
    public void handleInput(IInput input)
    {
        //Wrschl unnötig, wenn ich direkt subscribe
        char inputType = input.getInputType();
        switch (inputType)
        {
            case ActionInput._type:
                handleActionInput(input);
                break;

            default:
                break;
        }
    }
    private void handleActionInput(IInput input)
    {
        _player.undisplayPossibleActions();
        unsubscribeToActionInput();

        ActionInput actionInput = input as ActionInput;
        Move_Builder move_builder = new Move_Builder(_player);
        move_builder.init();
        InputManager.ConfirmBtnClicked += handleConfirmInput;
        //TODO subscribe to Confirm
    }
    private void handleConfirmInput(IInput input)
    {
        try
        {
            _currentActionBuilder.validateActionFinished();
            addPlayerActionToPlayerTurn(_currentActionBuilder.getAction());
        }
        catch (ActionNotFinishedException)
        {
            Debug.Log("Action is not finished");
        }        
    }

    private void subscribeToActionInput()
    {
        InputManager.ActionBtnClicked += handleActionInput;
    }
    private void unsubscribeToActionInput()
    {
        InputManager.ActionBtnClicked -= handleActionInput;
    }
    private void subscribeToConfirmInput()
    {
        InputManager.ConfirmBtnClicked += handleConfirmInput;
    }
    private void unsubscribeToConfirmInput()
    {
        InputManager.ConfirmBtnClicked -= handleConfirmInput;
    }

}
