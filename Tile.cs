using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int xValueOnMatrix;
    int yValueOnMatrix;

    public Vector2 position;

    List<Player> playersOnTile;
    bool isPlayerOnTile;

    public void registerPlayer(Player player)
    {
        playersOnTile.Add(player);
        isPlayerOnTile = true;
    }
    public void unregisterPlayer(Player player)
    {
        playersOnTile.Remove(player);
        isPlayerOnTile = false;
    }
}
