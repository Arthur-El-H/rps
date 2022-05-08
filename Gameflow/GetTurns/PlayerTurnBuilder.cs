using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnBuilder : MonoBehaviour
{
    TurnBuilder _turnBuilder;
    Vector2 _testPlaceOfCap = new Vector2(-7, 3);
    public Player _player;

    public Queue<IAction> _playerTurn;
    List<IActionCapability> _displayedActionCapabilities;

    public PlayerTurnBuilder(TurnBuilder turnBuilder, Player player)
    {
        _turnBuilder = turnBuilder;
        _player = player;
        //TODO get amountOfAction und amountOfActionALlowed
    }

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

    private void initPlayerActionBuilding()
    {
        displayPossibleActions(_player._possibleActions);
    }

    private void displayPossibleActions(List<IActionCapability> possibleActions)
    {
        foreach (var actionCap in possibleActions)
        {
            GameObject btn = actionCap.getActionDisplayObject();
            ButtonManager.moveBtn(btn, _testPlaceOfCap);
        }
    }

    private void undisplayPossibleActions()
    {
        // TODO Maybe by caching all built btn gameobjects and destroy or
        // maybe build all btns at the beginning and just set them to their
        // locations an enable / disable them.
    }

    private bool isActionQueueFull(Queue<IAction> _actionsOfPlayer)
    {
        return (_player._maxActionsPerTurn <= _actionsOfPlayer.Count);
    }

    public void init()
    {
        // TODO subscribe to Input manager
        displayPossibleActions(_player._possibleActions);
    }

    public void handleInput(IInput input)
    {
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
        undisplayPossibleActions();
        ActionInput actionInput = input as ActionInput;
        PlayerActionBuilder playerAction = new PlayerActionBuilder(_player, this, actionInput._actionCapability);
    }
}
