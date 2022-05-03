using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 10;
    public int maxActionsPerTurn;
    List<IActionCapability> possibleActions;
    private Tile _currentTile;

    private void Awake()
    {
        //possibleActions.Add(new )
    }

    internal void displayPossibleActions()
    {
        throw new NotImplementedException();
    }

    internal void undisplayPossibleActions()
    {
        throw new NotImplementedException();
    }

    public async Task moveTo(Tile tileToMoveTo)
    {
        //TODO better moving / Anim
        for (int i = 0; i < 180; i++)
        {
            await Task.Yield();
        }

        tileToMoveTo.registerPlayer(this);
        _currentTile.unregisterPlayer(this);
        _currentTile = tileToMoveTo;
    }
}
