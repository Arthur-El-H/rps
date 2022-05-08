using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBuilder: MonoBehaviour
{
    private IngameManager _ingameManager;
    private List<Player> _players;
    List<Queue<IAction>> _actionsOfAllPlayers;

    public TurnBuilder(List<Player> players, IngameManager ingameManager)
    {
        _ingameManager = ingameManager;
        _players = players;
    }

    public void init()
    {
        _actionsOfAllPlayers = new List<Queue<IAction>>();
        int amountOfTurnsAdded = _actionsOfAllPlayers.Count;
        foreach (var player in _players)
        {
            initPlayerTurnBuilding(player);
        }
    }

    private void initPlayerTurnBuilding(Player player)
    {
        new PlayerTurnBuilder(this, player);
    }

    public void addPlayersTurn(Queue<IAction> actionsOfPlayer)
    {
        _actionsOfAllPlayers.Add(actionsOfPlayer);
        if (isEveryTurnSetAlready())
        {
            _ingameManager.playeOutTurn(_actionsOfAllPlayers);
        }
    }

    private bool isEveryTurnSetAlready()
    {
        return _actionsOfAllPlayers.Count >= _players.Count;
    }
}
