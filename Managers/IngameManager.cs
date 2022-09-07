using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public struct intVector
    {
        public intVector(int givenX, int givenY)
        {           
            x = givenX;
            y = givenY;
        }
        public int x;
        public int y;
    }

    [SerializeField] private Map _map;

    [SerializeField] public GameObject _pref_player;
    [SerializeField] int _amountOfPlayers = 2;

    List<Player> _players = new List<Player>();
    private int _currentPlayers;

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
            intVector playerPos = getNextPlayerTilePos();
            var tileToSpawnOn = _map.getTile(playerPos.x, playerPos.y);
            var playerObject = Instantiate(_pref_player, new Vector2(0,0), Quaternion.identity);
            var player = playerObject.GetComponent<Player>();
            _players.Add(player);
            player.spawnOn(tileToSpawnOn);
        }
    }

    private intVector getNextPlayerTilePos()
    {
        intVector result = new intVector(0, 0);
        switch (_currentPlayers)
        {
            case 0:
                result = new intVector(0, 0);
                break;

            case 1:
                result = new intVector(7, 7);
                break;
        }       
        _currentPlayers++;
        return result;
    }
}