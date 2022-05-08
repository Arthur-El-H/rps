using System.Collections.Generic;
using UnityEngine;

public class TileInput : IInput
{
    public static char _type = InputManager.tileInputType;
    public Tile _selectedTile;

    public TileInput( Tile selectedTile )
    {
        _selectedTile = selectedTile;
    }

    public char getInputType()
    {
        return _type;
    }

}