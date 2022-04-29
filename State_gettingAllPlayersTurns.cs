using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingAllPlayersTurns : IState
{
    int _amountOfPlayersWhoseActionsWeGot;
    public List<Player> _players;
    public statemachine _statemachine;

    List<Queue<actionBase>> _actionsOfAllPlayers;

    public State_gettingAllPlayersTurns(statemachine statemachine, List<Player> players, List<Queue<actionBase>> actionsOfAllPlayers = null)
    {
        _statemachine = statemachine;
        if (actionsOfAllPlayers == null)
        {
            _actionsOfAllPlayers = new List<Queue<actionBase>>();
        }
        else
        {
            _actionsOfAllPlayers = actionsOfAllPlayers;
        }
        _players = players;
    }

    public void Enter()
    {
        if (_amountOfPlayersWhoseActionsWeGot == )
        {

        }
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }

    public void handleInput(IInput input)
    {
        char inputType = input.getInputType();
        switch (inputType)
        {
            default:
                break;
        }
    }

    public void addPlayersTurnToCompleteTurn(Queue<actionBase> actionsOfPlayer)
    {
        _actionsOfAllPlayers.Add(actionsOfPlayer);
        int amountOfTurnsAdded = _actionsOfAllPlayers.Count;
        if (amountOfTurnsAdded >= _players.Count)
        {
            // Change statemachine to "playingOutTurn"
        }
        else
        {
            State_gettingPlayersTurn nextState = new State_gettingPlayersTurn(_statemachine, _players[amountOfTurnsAdded]);
        }
    }
}
