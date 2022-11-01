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

    public Action<PlayerTurnBuilder> ActionBuildingCancelled;
    public Action<PlayerTurnBuilder> ActionBuildingConfirmed;

    public void subscribeToConfirmation(Action<PlayerTurnBuilder> action)
    {
        ActionBuildingConfirmed += action;
    }
    public void unsubscribeToConfirmation(Action<PlayerTurnBuilder> action)
    {
        ActionBuildingConfirmed -= action;
    }
    public void subscribeToCancellation(Action<PlayerTurnBuilder> action)
    {
        ActionBuildingCancelled += action;
    }
    public void unsubscribeToCancellation(Action<PlayerTurnBuilder> action)
    {
        ActionBuildingCancelled -= action;
    }

    public PlayerTurnBuilder(TurnBuilder turnBuilder, Player player)
    {
        //_turnBuilder = turnBuilder;
        _player = player;
        //_player._maxActionsPerTurn = 2;
        _playerTurn = new Queue<IAction>();
        //TODO get amountOfAction und amountOfActionALlowed
    }
    public void init()
    {
        initPlayerActionBuilding();
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
        return _player._maxActionsPerTurn <= _actionsOfPlayer.Count;
    }
    private void initPlayerActionBuilding()
    {
        _player.displayPossibleActions();
        InputManager.subscribeToActionBtnClicked(handleActionInput);
    }

    internal void registerAssignedTurn(TurnBuilder turnBuilder)
    {

    }

    private void handleActionInput(IInput input)
    {
        _player.undisplayPossibleActions();
        InputManager.unsubscribeToActionBtnClicked(handleActionInput);

        ActionInput actionInput = input as ActionInput;
        _currentActionBuilder = new Move_Builder(_player);
        _currentActionBuilder.init();
        InputManager.subscribeToConfirmBtnClicked(handleConfirmInput);
    }
    private void handleConfirmInput(IInput input)
    {
        try
        {
            _currentActionBuilder.validateActionFinished();
            InputManager.unsubscribeToConfirmBtnClicked(handleConfirmInput);
            addPlayerActionToPlayerTurn(_currentActionBuilder.getAction());
        }
        catch (ActionNotFinishedException)
        {
            Debug.Log("Action is not finished");
        }        
    }
}
