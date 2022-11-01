using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBuilder
{
    private Turn _turn;
    private Player _player;
    List<Queue<IAction>> _turnToBuild;


    public TurnBuilder(Player player)
    {
        _player = player;
    }

    public void init()
    {
        _turnToBuild = new List<Queue<IAction>>();
        int amountOfTurnsAdded = _turnToBuild.Count;

        //For now only one player
        initPlayerTurnBuilding(_player);

        //TODO: Implement for all players later
        //foreach (var player in _players)
        //{
        //    initPlayerTurnBuilding(player);
        //}
    }


    public void addPlayersTurn(Queue<IAction> actionsOfPlayer)
    {
        _turnToBuild.Add(actionsOfPlayer);
        if (isEveryTurnSetAlready())
        {
            _turn = new Turn(_turnToBuild);
            _turn.playOut();
        }
        else
        {
            //initPlayerTurnBuilding(_players[1]);
        }
    }

    private void initPlayerTurnBuilding(Player player)
    {
        var newTurn = new PlayerTurnBuilder(this, player);
        newTurn.init();
        newTurn.registerAssignedTurn(this);
    }

    private bool isEveryTurnSetAlready()
    {
        //return _turnToBuild.Count >= _players.Count;
        return true;
    }

    internal Turn getTurn()
    {
        return new Turn(_turnToBuild);
    }
}
