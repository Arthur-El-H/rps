using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBtn : MonoBehaviour
{
    public Player _player;
    public int _actionCode;

    public void createAction()
    {
        _player.addAction(_actionCode);
    }
}
