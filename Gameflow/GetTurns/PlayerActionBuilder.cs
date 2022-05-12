using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionBuilder : MonoBehaviour
{
    PlayerTurnBuilder _playerTurnBuilder;
    IActionCapability _actionCapability;
    IAction _action;
    Player _player;

    public PlayerActionBuilder(Player player, PlayerTurnBuilder turn, IActionCapability actionCapability)
    {
        _actionCapability = actionCapability;
        _playerTurnBuilder = turn;
        _player = player;
    }

    public void handleInput(IInput input)
    {
        // instead make actionCap subscribe to Inputmanager
        //_actionCapability.handleInput(input);
    }

    internal void finishAction()
    {
        _playerTurnBuilder.addPlayerActionToPlayerTurn(_action);
    }
}
