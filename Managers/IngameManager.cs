using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private Map _map;

    [SerializeField] public GameObject _pref_player;
    [SerializeField] int _amountOfPlayers = 2;

    List<Player> _players = new List<Player>();

    void Start()
    {
        //TODO init Players in their own method
        _map.init();
        InputManager.init();
        setPlayersOnMap();
        new TurnBuilder(_players, this).init();
        Application.targetFrameRate = 30;
    }

    private void setPlayersOnMap()
    {
        //TODO make it scale for more players
        for (int i = 0; i < _amountOfPlayers; i++)
        {
            switch (i)
            {
                case 0:
                    _players.Add( Instantiate(_pref_player, _map.getTile(0, 0)._worldPosition, Quaternion.identity).
                    GetComponent<Player>());
                    _map.getTile(0, 0).registerPlayer(_players[0]);
                    _players[0]._currentTile = _map.getTile(0,0);

                    break;
                case 1:
                    _players.Add(Instantiate(_pref_player, _map.getTile(7, 7)._worldPosition, Quaternion.identity).
                    GetComponent<Player>());
                    _map.getTile(7, 7).registerPlayer(_players[1]);
                    _players[1]._currentTile = _map.getTile(7, 7);

                    break;
                default:
                    break;
            }
        }
    }
}
