using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Turn : MonoBehaviour
{
    private List<Queue<IAction>> _playerActions;
    private int amountOfPlayers;

    public Turn(List<Queue<IAction>> playerActions)
    {
        _playerActions = playerActions;
        amountOfPlayers = _playerActions.Count;
    }

    public void playOut()
    {
        while (isAtLeastOneActionLeft())
        {
            playOutEachPlayersNextAction();
        }
    }

    private void playOutEachPlayersNextAction()
    {
        Task[] actionsToPlay = getArrayOfAllActionsToPlayOut();        
        Task.WaitAll(actionsToPlay);
    }

    private Task[] getArrayOfAllActionsToPlayOut()
    {
        Task[] actionsToPlay = new Task[amountOfPlayers];
        for (int i = 0; i < amountOfPlayers; i++)
        {
            if (isEmpty(_playerActions[i]))
            {
                continue;
            }
            actionsToPlay[i] = _playerActions[i].Dequeue().act(); 
        }
        return actionsToPlay;
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
