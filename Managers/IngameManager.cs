using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public statemachine _statemachine;
    [SerializeField] Map _map;
    [SerializeField] GameObject _Pref_Player;
    [SerializeField] int _amountOfPlayers = 2;

    List<Player> _players;

    void Start()
    {
        _map.init();
        setPlayersOnMap();
        _statemachine = new statemachine();
    }

    private void setPlayersOnMap()
    {
        for (int i = 0; i < _amountOfPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    _players.Add( Instantiate(_Pref_Player, _map.getTile(0, 0).position, Quaternion.identity).
                    GetComponent<Player>());
                    break;
                case 1:
                    _players.Add(Instantiate(_Pref_Player, _map.getTile(8, 8).position, Quaternion.identity).
                    GetComponent<Player>());
                    break;
                default:
                    break;
            }
        }
    }

    void Update()
    {
        
    }
}
