using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Tile[,] _tilesMatrix;
    int _currentAmountOfPlayers;

    [SerializeField] int _length = 8;
    [SerializeField] int _height = 8;


    [SerializeField] float _tileLength = 1;
    [SerializeField] Vector2 _zeroTilePos;

    [SerializeField] GameObject _Pref_tile;

    internal void init( )
    {
        _tilesMatrix = new Tile[_length, _height];
        _zeroTilePos = new Vector2(-4, 4);
        constructMap();
    }

    private void constructMap()
    {
        float xPosOfTile = _zeroTilePos.x;
        float yPosOfTile = _zeroTilePos.y;

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                _tilesMatrix[j, i] = createTile(new Vector2(xPosOfTile, yPosOfTile),
                                                new Vector2(j,i) );
                xPosOfTile += _tileLength;
            }
            xPosOfTile = _zeroTilePos.x;
            yPosOfTile -= _tileLength;
        }
    }

    private Tile createTile(Vector2 posInWorld, Vector2 posInMatrix)
    {
        Tile newTile = Instantiate(_Pref_tile, posInWorld, Quaternion.identity, this.transform).GetComponent<Tile>();
        newTile._worldPosition = posInWorld;
        newTile._matrixPosition = posInMatrix;
        return newTile;
    }

    public Tile getTile(int xValue, int yValue)
    {
        return _tilesMatrix[xValue, yValue];
    }

    public intVector getNextPlayerTilePos()
    {
        intVector result = new intVector(0, 0);
        switch (_currentAmountOfPlayers)
        {
            case 0:
                result = new intVector(0, 0);
                break;

            case 1:
                result = new intVector(7, 7);
                break;
        }
        _currentAmountOfPlayers++;
        return result;
    }
}
