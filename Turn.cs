using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class Turn : MonoBehaviour
{
    List<Queue<IAction>> playerActions;

    public async void playOut()
    {
        int amountOfPlayers = playerActions.Count;
        int amountOfPlayersWhoseTurnIsFinished = 0;
        while (amountOfPlayers != amountOfPlayersWhoseTurnIsFinished)
        {
            amountOfPlayersWhoseTurnIsFinished = 0;
            foreach ( Queue<IAction> actionQueue in playerActions )
            {
                if (isEmpty(actionQueue))
                {
                    amountOfPlayersWhoseTurnIsFinished++;
                    return;
                }
                IAction nextAction = actionQueue.Dequeue();
                Task t = nextAction.act(); //TODO AWAIT
                await(t);
            }
        }
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
