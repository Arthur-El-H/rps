using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Capability : IActionCapability
{
    Player _player;
    GameObject _moveBtn;
    GameObject _pref_actionDisplay;
    Canvas _canvas;

    public Move_Capability()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _pref_actionDisplay = Prefabs.Instance.prefab_ActMoveDisplay;
        _moveBtn = GameObject.Instantiate(_pref_actionDisplay, _canvas.transform);
        //TODO: ...
        _moveBtn.GetComponent<Button>().onClick.AddListener(delegate 
            { InputManager.registerActionInput(new ActionInput(new Move_Builder(_player))); });
    }

    public GameObject getActionDisplayObject()
    {        
        return _moveBtn;
    }
}

