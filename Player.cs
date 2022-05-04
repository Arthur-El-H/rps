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

    Vector2 _testPlaceOfCap = new Vector2(-7,9);

    private void Awake()
    {
        possibleActions = new List<IActionCapability>();
        possibleActions.Add(new ActCap_Move());
    }

    internal void displayPossibleActions()
    {
        foreach (var actionCap in possibleActions)
        {
            GameObject btn = actionCap.getActionDisplayObject();
            btn.GetComponent<ActCap_Move_Btn>().moveBtn(_testPlaceOfCap);
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
            await Task.Yield();
        }

        tileToMoveTo.registerPlayer(this);
        _currentTile.unregisterPlayer(this);
        _currentTile = tileToMoveTo;
    }
}
