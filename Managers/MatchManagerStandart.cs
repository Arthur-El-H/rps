using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MatchManagerStandart : MonoBehaviour, IMatchManager
{
    [SerializeField] private Map _map;
    [SerializeField] public GameObject _pref_player;
    [SerializeField] int _amountOfPlayers = 1;

    List<Player> _players = new List<Player>();

    List<TurnBuilder> _playersTurnBuilders = new List<TurnBuilder>();
    List<Turn> _playersTurns = new List<Turn>();

    int turnSelectionTimeInMs = 30000;
    private int _confirmedTurns;
    private Task delayedTurnFinalization;

    enum State { turnSelection, runningRound}

    public MatchManagerStandart(int amountOfPlayers)
    {
        _amountOfPlayers = amountOfPlayers;

        InputManager.init();
        _map.init();
        setPlayersOnMap();

        getTurns();
    }

    private void getTurns()
    {
        // in future, we will divide here onto different machines
        // for now, only one player gets his turn, so we can implement this first
        _playersTurnBuilders.Add(new TurnBuilder(_players[0]));
        delayedTurnFinalization = delayingTurnFinalization(turnSelectionTimeInMs);
    }

    private async Task delayingTurnFinalization(int turnSelectionTimeInMs)
    {
        await Task.Delay(turnSelectionTimeInMs);
        finalizeTurns();
    }

    private void finalizeTurns()
    {
        closeTurnSelection();
        foreach (TurnBuilder turnBuilder in _playersTurnBuilders)
        {
            _playersTurns.Add(turnBuilder.getTurn());
        }
    }

    private void closeTurnSelection()
    {
        foreach (var turn in _playersTurns)
        {
            //undisplay...
        }
    }

    public void confirmTurn(Turn turn)
    {
        _confirmedTurns++;
        if (_confirmedTurns == _players.Count)
        {
            delayedTurnFinalization?.Dispose();
            finalizeTurns();
        }
    }

    private void setPlayersOnMap()
    {
        for (int i = 0; i < _amountOfPlayers; i++)
        {
            intVector playerPos = _map.getNextPlayerTilePos();
            var tileToSpawnOn = _map.getTile(playerPos.x, playerPos.y);
            var playerObject = Instantiate(_pref_player, new Vector2(0, 0), Quaternion.identity);
            var player = playerObject.GetComponent<Player>();
            _players.Add(player);
            player.spawnOn(tileToSpawnOn);
        }
    }

}
