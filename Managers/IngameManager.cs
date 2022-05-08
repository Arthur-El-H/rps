using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public statemachine _statemachine;
    [SerializeField] private Map _map;

    [SerializeField] public GameObject _pref_player;
    [SerializeField] int _amountOfPlayers = 2;

    List<Player> _players = new List<Player>();

    void Start()
    {
        _map.init();
        setPlayersOnMap();
        _statemachine = new statemachine();
        _statemachine.changeState(new State_gettingAllPlayersTurns(_statemachine, _players));
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
                    break;
                case 1:
                    _players.Add(Instantiate(_pref_player, _map.getTile(7, 7)._worldPosition, Quaternion.identity).
                    GetComponent<Player>());
                    break;
                default:
                    break;
            }
        }
    }

    public void playeOutTurn(List<Queue<IAction>> _actionsOfAllPlayers)
    {
        List<Task> actionTasks = new List<Task>();
        int emptyQueues = 0;
        int amountOfQueues = _actionsOfAllPlayers.Count;
        bool isQueuesEmpty = false;

        while (!isQueuesEmpty)
        {
            foreach (Queue<IAction> actionQueue in _actionsOfAllPlayers)
            {
                if (actionQueue.Count == 0)
                {
                    emptyQueues++;
                }
                else
                {
                    actionTasks.Add(actionQueue.Dequeue().act());
                }
            }
            if (emptyQueues == amountOfQueues)
            {
                isQueuesEmpty = true;
            }
            Task.WhenAll(actionTasks);
        }
    }

}
