using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int xValueOnMatrix;
    int yValueOnMatrix;
    Vector2 position;

    List<Player> playersOnTile;
    bool isPlayerOnTile;
}
