using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tile : MonoBehaviour
{
    public Vector2 _worldPosition;
    public Vector2 _matrixPosition;

    List<Player> _playersOnTile;

    private void Awake()
    {
        Debug.Log("Hello");
    }
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
        Debug.Log("is unmarked");
    }

    internal void mark()
    {
        Debug.Log("is marked");
    }

    private void OnMouseDown()
    {
        Debug.Log("is clicked");
        InputManager.registerTileInput(new TileInput(this));
    }
}
