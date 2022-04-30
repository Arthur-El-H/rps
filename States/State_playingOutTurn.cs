using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class State_playingOutTurn: IState
{
    private statemachine _statemachine;
    private List<Queue<ActionBase>> _actionsOfAllPlayers;

    public State_playingOutTurn(statemachine statemachine, List<Queue<ActionBase>> actionsOfAllPlayers)
    {
        this._statemachine = statemachine;
        this._actionsOfAllPlayers = actionsOfAllPlayers;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
        List<Task> actionTasks = new List<Task>();
        int emptyQueues = 0;
        int amountOfQueues = _actionsOfAllPlayers.Count;
        bool isQueuesEmpty = false;

        while (!isQueuesEmpty)
        {
            foreach (Queue<ActionBase> actionQueue in _actionsOfAllPlayers)
            {
                if (actionQueue.Count == 0)
                {
                    emptyQueues++;
                }
                else
                {
                    actionTasks.Add(actionQueue.Dequeue().Act());
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