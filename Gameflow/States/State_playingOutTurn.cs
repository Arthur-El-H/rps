﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class State_playingOutTurn: IState
{
    private statemachine _statemachine;
    private List<Queue<IAction>> _actionsOfAllPlayers;

    public State_playingOutTurn(statemachine statemachine, List<Queue<IAction>> actionsOfAllPlayers)
    {
        this._statemachine = statemachine;
        this._actionsOfAllPlayers = actionsOfAllPlayers;
    }

    public void init()
    {      
    }

    public void Execute()
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


    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void handleInput(IInput input)
    {
        throw new System.NotImplementedException();
    }
}