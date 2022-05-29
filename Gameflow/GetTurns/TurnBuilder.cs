using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBuilder
{
    private Turn _turn;
    private IngameManager _ingameManager;
    private List<Player> _players;
    List<Queue<IAction>> _turnToBuild;

    public TurnBuilder(List<Player> players, IngameManager ingameManager)
    {
        _ingameManager = ingameManager;
        _players = players;
    }

    public void init()
    {
        _turnToBuild = new List<Queue<IAction>>();
        int amountOfTurnsAdded = _turnToBuild.Count;

        //For now only one player
        initPlayerTurnBuilding(_players[0]);

        //TODO: Implement for all players later
        //foreach (var player in _players)
        //{
        //    initPlayerTurnBuilding(player);
        //}
    }

    private void initPlayerTurnBuilding(Player player)
    {
        new PlayerTurnBuilder(this, player).init();
    }

    public void addPlayersTurn(Queue<IAction> actionsOfPlayer)
    {
        _turnToBuild.Add(actionsOfPlayer);
        if (isEveryTurnSetAlready())
        {
            _turn = new Turn(_turnToBuild);
            _turn.playOut();
        }
    }

    private bool isEveryTurnSetAlready()
    {
        return _turnToBuild.Count >= _players.Count;
    }
}
