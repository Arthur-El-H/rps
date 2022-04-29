using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    List<Queue<actionBase>> playerActions;

    public void playOut()
    {
        int amountOfPlayers = playerActions.Count;
        int amountOfPlayersWhoseTurnIsFinished = 0;
        while (amountOfPlayers != amountOfPlayersWhoseTurnIsFinished)
        {
            amountOfPlayersWhoseTurnIsFinished = 0;
            foreach ( Queue<actionBase> actionQueue in playerActions )
            {
                if (isEmpty(actionQueue))
                {
                    amountOfPlayersWhoseTurnIsFinished++;
                    return;
                }
                actionBase nextAction = actionQueue.Dequeue();
                nextAction.act(); //TODO AWAIT
            }
        }
    }

    private bool isEmpty(Queue<actionBase> queue)
    {
        if (queue.Count == 0)
        {
            return true;
        }
        return false;
    }
}
