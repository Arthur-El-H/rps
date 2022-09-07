using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tile : MonoBehaviour
{
    public Vector2 _worldPosition;
    public Vector2 _matrixPosition;
    public SpriteRenderer _renderer;

    public List<Player> _playersOnTile = new List<Player>();

    private static Color _marked = Color.green; //new Color(255, 100, 125);
    private static Color _unmarked = Color.white;//new Color(255, 255, 255);

    private void Awake()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
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

    internal bool isAdjacentTo(Tile tile)
    {
        var xDifference = Math.Abs(_matrixPosition.x - tile._matrixPosition.x);
        var yDifference = Math.Abs(_matrixPosition.y - tile._matrixPosition.y);
        if (xDifference < 2 && yDifference < 2) return true;
        return false;
    }

    public void demark()
    {
        Debug.Log("unmarked");
        _renderer.color = _unmarked;
    }

    public void mark()
    {
        Debug.Log("marked");
        _renderer.color = _marked;
    }

    private void OnMouseDown()
    {
        InputManager.registerTileInput(new TileInput(this));
    }
}
