using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Tile[,] _tilesMatrix;

    [SerializeField] int _length = 8;
    [SerializeField] int _height = 8;


    [SerializeField] float _tileLength = 1;
    [SerializeField] Vector2 _zeroTilePos;

    [SerializeField] GameObject _Pref_tile;

    internal void init( )
    {
        constructMap();
    }

    private void Awake()
    {
        _tilesMatrix = new Tile[_length, _height];
        _zeroTilePos = new Vector2(-4, 4);
    }

    void Start()
    {
    }

    private void constructMap()
    {
        float xPosOfTile = _zeroTilePos.x;
        float yPosOfTile = _zeroTilePos.y;

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                _tilesMatrix[j, i] = createTile(xPosOfTile,yPosOfTile);
                xPosOfTile += _tileLength;
            }
            xPosOfTile = _zeroTilePos.x;
            yPosOfTile -= _tileLength;
        }
    }

    private Tile createTile(float xPosOfTile, float yPosOfTile)
    {
        var pos = new Vector2(xPosOfTile, yPosOfTile);
        Tile newTile = Instantiate(_Pref_tile, pos, Quaternion.identity).GetComponent<Tile>();
        newTile.position = pos;
        return newTile;
    }

    public Tile getTile(int xValue, int yValue)
    {
        return _tilesMatrix[xValue, yValue];
    }
}
