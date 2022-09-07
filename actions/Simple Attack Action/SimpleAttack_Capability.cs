using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAttack_Capability : IActionCapability
{
    Player _player;
    GameObject _moveBtn;
    GameObject _pref_simpleAttackBtn;
    Canvas _canvas;

    public SimpleAttack_Capability()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _pref_simpleAttackBtn = Prefabs.Instance.prefab_simpleAttackBtn;
        _moveBtn = GameObject.Instantiate(_pref_simpleAttackBtn, _canvas.transform);
        //TODO: ...
        _moveBtn.GetComponent<Button>().onClick.AddListener(delegate
        { InputManager.registerActionInput(new ActionInput(new SimpleAttack_Builder(_player))); });
    }

    public GameObject getActionDisplayObject()
    {
        return _moveBtn;
    }
}
