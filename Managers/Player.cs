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
    public List<GameObject> _actionCapabilityBtns;
    private Tile _currentTile;
    GameObject _pref_actionDisplay;
    InputManager _inputManager;


    private void Awake()
    {
        _possibleActions = new List<IActionCapability>();
        _possibleActions.Add(new MoveActionCapability(this));

        foreach (var actionCapability in _possibleActions)
        {
            actionCapability.setInputManager(_inputManager);
            _actionCapabilityBtns.Add(actionCapability.getActionDisplayObject());
        }
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

    internal void displayPossibleActions()
    {
        foreach (GameObject actionBtn in _actionCapabilityBtns)
        {
            actionBtn.SetActive(true);
        }
    }

    internal void undisplayPossibleActions()
    {
        foreach (GameObject actionBtn in _actionCapabilityBtns)
        {
            actionBtn.SetActive(false);
        }
    }
}
