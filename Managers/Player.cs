using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _health = 10;
    public int _maxActionsPerTurn = 2;
    public List<IActionCapability> _possibleActions = new List<IActionCapability>();
    public List<GameObject> _actionCapabilityBtns;
    public Tile _currentTile;


    private void Awake()
    {
        setPossibleActions();

        foreach (var actionCapability in _possibleActions)
        {
            GameObject btn = actionCapability.getActionDisplayObject();
            _actionCapabilityBtns.Add(btn);
            btn.SetActive(false);

        }
    }

    public async Task moveTo(Tile tileToMoveTo)
    {
        //TODO better moving / Anim
        for (int i = 0; i < Turn.framesOfFirstHalf; i++)
        {
            if (i==0)
            {
                Debug.Log("going in 3 seconds");
            }
            await Task.Yield();
            // TODO Bug happens here and game crashes (await Task.Yield()) 
        }

        Debug.Log("Moved");

        tileToMoveTo.registerPlayer(this);
        _currentTile.unregisterPlayer(this);
        _currentTile = tileToMoveTo;
        this.transform.position = tileToMoveTo._worldPosition;
    }

    internal void displayPossibleActions()
    {
        foreach (GameObject actionBtn in _actionCapabilityBtns)
        {
            actionBtn.SetActive(true);
            // TODO: maybe let it be placed by buttonManager? Or by who?
        }
    }

    internal void undisplayPossibleActions()
    {
        foreach (GameObject actionBtn in _actionCapabilityBtns)
        {
            actionBtn.SetActive(false);
        }
    }

    public void setPossibleActions()
    {
        _possibleActions.Add(new Move_Capability());
    }
}
