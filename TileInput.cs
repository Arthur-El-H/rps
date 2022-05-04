using System.Collections.Generic;
using UnityEngine;

public class TileInput : IInput
{
    public IAction _action;
    public static char _type = 'a';
    public Tile _goalTile;

    public TileInput()
    {

    }

    public char getInputType()
    {
        return _type;
    }

}