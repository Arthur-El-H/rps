using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_gettingAllPlayersTurns : IState
{
    public List<Player> _players;
    public statemachine _statemachine;

    List<Queue<ActionBase>> _actionsOfAllPlayers;

    public State_gettingAllPlayersTurns(statemachine statemachine, List<Player> players)
    {
        _statemachine = statemachine;
        _players = players;
    }

    public void Enter()
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
        char inputType = input.getInputType();
        switch (inputType)
        {
            default:
                break;
        }
    }

    public void addPlayersTurnToCompleteTurn(Queue<ActionBase> actionsOfPlayer)
    {
        _actionsOfAllPlayers.Add(actionsOfPlayer);
        int amountOfTurnsAdded = _actionsOfAllPlayers.Count;
        if (amountOfTurnsAdded >= _players.Count)
        {
            State_playingOutTurn nextState = new State_playingOutTurn(_statemachine, _actionsOfAllPlayers);
            _statemachine.changeState(nextState);
        }
        else
        {
            State_gettingPlayersTurn nextState = new State_gettingPlayersTurn(_statemachine, _players[amountOfTurnsAdded], this);
            _statemachine.changeState(nextState);
        }
    }
}
