using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _health = 10;
    public int _maxActionsPerTurn;
    public List<IActionCapability> _possibleActions;
    private Tile _currentTile;

    private void Awake()
    {
        _possibleActions = new List<IActionCapability>();
        _possibleActions.Add(new ActCap_Move(this));
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
            if (i==0)
            {
                Console.WriteLine("going in 3 seconds");
            }
            await Task.Yield();
        }

        tileToMoveTo.registerPlayer(this);
        _currentTile.unregisterPlayer(this);
        _currentTile = tileToMoveTo;
        this.transform.position = tileToMoveTo._worldPosition;
    }
}
