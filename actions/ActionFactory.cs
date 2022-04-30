using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory 
{
    public Act_Move getAct_Move(Player player, List<Tile> goals)
    {
        return new Act_Move(player, goals);
    }
}
