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

    Vector2 _testPlaceOfCap = new Vector2(-7,3);

    private void Awake()
    {
        possibleActions = new List<IActionCapability>();
        possibleActions.Add(new ActCap_Move(this));
    }

    internal void displayPossibleActions()
    {
        foreach (var actionCap in possibleActions)
        {
            GameObject btn = actionCap.getActionDisplayObject();
            ButtonManager.moveBtn(btn, _testPlaceOfCap);
        }
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
