using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health;
    public int maxActionsPerTurn;
    List<actionCapabilityBase> possibleActions;

    internal void displayPossibleActions()
    {
        throw new NotImplementedException();
    }

    internal void undisplayPossibleActions()
    {
        throw new NotImplementedException();
    }
}
