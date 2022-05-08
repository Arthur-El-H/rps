using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2 _worldPosition;
    public Vector2 _matrixPosition;

    List<Player> _playersOnTile;
    public bool _isPlayerOnTile()
    {
        return (_playersOnTile.Count != 0);
    }

    public void registerPlayer(Player player)
    {
        _playersOnTile.Add(player);
    }
    public void unregisterPlayer(Player player)
    {
        _playersOnTile.Remove(player);
    }

    internal void demark()
    {
        throw new NotImplementedException();
    }

    internal void mark()
    {
        throw new NotImplementedException();
    }
}
