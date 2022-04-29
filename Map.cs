using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    Tile[,] tilesMatrix; //= new Tile[5, 3];
    //myFloats[0, 0] = 1.0f;

    int length = 8;
    int height = 8;

    float tileLength;
    Vector2 zeroTilePos;

    private void Awake()
    {
        tilesMatrix = new Tile[length, height];
    }

    void Start()
    {
        constructMap();
    }

    private void constructMap()
    {
        float xPosOfTile = zeroTilePos.x;
        float yPosOfTile = zeroTilePos.y;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < length; j++)
            {
                tilesMatrix[j, i] = createTile(xPosOfTile,yPosOfTile);
                xPosOfTile += tileLength;
            }
            xPosOfTile = zeroTilePos.x;
            yPosOfTile += tileLength;
        }
    }

    private Tile createTile(float xPosOfTile, float yPosOfTile)
    {
        throw new NotImplementedException();
    }
}
