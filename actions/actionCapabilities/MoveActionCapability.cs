using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveActionCapability : IActionCapability
{
    Player _player;
    GameObject _moveBtn;
    GameObject _pref_actionDisplay;
    Canvas _canvas;
    InputManager _inputManager;
    PlayerTurnBuilder playerTurnBuilder;

    public MoveActionCapability(Player player)
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _pref_actionDisplay = Prefabs.Instance.prefab_ActMoveDisplay;
        _player = player;
        _moveBtn = GameObject.Instantiate(_pref_actionDisplay, _canvas.transform);
        _moveBtn.GetComponent<Button>();
    }

    public void createAction(PlayerTurnBuilder playerTurnBuilder)
    {
        ActionInput actionInput = new ActionInput(new MoveActionBuilder(_player));
        InputManager.registerActionInput(actionInput);
    }

    public GameObject getActionDisplayObject()
    {        
        return _moveBtn;
    }

    public void setInputManager(InputManager inputManager)
    {
        _inputManager = inputManager;
    }
}

