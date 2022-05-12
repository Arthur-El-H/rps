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
    public void init()
    {
        InputManager.ActionBtnClicked += handleActionInput;
        _player.displayPossibleActions();
    }
    private void initPlayerActionBuilding()
    {
        _player.displayPossibleActions();
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
        //unsubscribe to inputmanager

        //ActionInput actionInput = input as ActionInput;
        //PlayerActionBuilder playerAction = new PlayerActionBuilder(_player, this, actionInput._actionBuilder);
    }
}
