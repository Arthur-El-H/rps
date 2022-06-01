using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Turn 
{
    private List<Queue<IAction>> _playerActions;
    private int amountOfPlayers;

    public const int startingInFirstHalf = 1;
    public const int startingInSecondHalf = 2;
    public const int framesOfFirstHalf = 180;

    public Turn(List<Queue<IAction>> playerActions)
    {
        _playerActions = playerActions;
        amountOfPlayers = _playerActions.Count;
    }

    public async void playOut()
    {
        while (isAtLeastOneActionLeft())
        {
            await playOutEachPlayersNextAction();
            Debug.Log("one charge finished");
        }
    }

    private async Task playOutEachPlayersNextAction()
    {
        List<IAction> ActionstartingInFirstHalf = new List<IAction>();
        List<IAction> ActionstartingInSecondHalf = new List<IAction>();
        for (int i = 0; i < amountOfPlayers; i++)
        {
            if (isEmpty(_playerActions[i]))
            {
                continue;
            }

            var actionToPlay = _playerActions[i].Dequeue();
            switch (actionToPlay.halfToStartAt())
            {
                case startingInFirstHalf:
                    ActionstartingInFirstHalf.Add(actionToPlay);
                    break;
                case startingInSecondHalf:
                    ActionstartingInSecondHalf.Add(actionToPlay);
                    break;
            }
        }

        List<Task> actions = new List<Task>();
        foreach (var action in ActionstartingInFirstHalf)
        {
            actions.Add(action.act());
        }
        for (int i = 0; i < framesOfFirstHalf; i++)
        {
            await Task.Yield();
        }
        foreach (var action in ActionstartingInSecondHalf)
        {
            actions.Add(action.act());
        }
        await Task.WhenAll(actions);
    }

    private bool isAtLeastOneActionLeft()
    {
        foreach (var action in _playerActions)
        {
            if (action.Count > 0)
            {
                return true;
            }
        }
            return false;
    }

    private bool isEmpty(Queue<IAction> queue)
    {
        if (queue.Count == 0)
        {
            return true;
        }
        return false;
    }
}
