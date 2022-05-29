using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    protected static Canvas _canvas;
    protected static GameObject _confirmBtnObj;
    protected static Button _confirmBtn;
    protected static Vector2 _posConfirmBtn = new Vector2(5,3);

    public const char actionInputType = 'a';
    public const char tileInputType = 'b';

    public const char confirmBtnInputType = 'c';
    public const char backBtnInputType = 'd';
    public const char enterBtnInputType = 'e';

    public static Action<TileInput> TileClicked;
    public static Action<ActionInput> ActionBtnClicked;
    public static Action<ConfirmInput> ConfirmBtnClicked;


    public static void init()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _confirmBtnObj = Instantiate(Prefabs.Instance.prefab_ConfirmBtn, _canvas.transform);
        ButtonManager.moveBtn(_confirmBtnObj, _posConfirmBtn);
        _confirmBtnObj.GetComponent<Button>().onClick.AddListener(delegate
        { InputManager.registerConfirmInput(new ConfirmInput()); });
        _confirmBtnObj.SetActive(false);
    }
    public static void subscribeToTileClicked(Action<TileInput> action)
    {
        TileClicked += action;
    }
    public static void unsubscribeToTileClicked(Action<TileInput> action)
    {
        TileClicked -= action;
    }

    public static void subscribeToActionBtnClicked(Action<ActionInput> action)
    {
        ActionBtnClicked += action;
    }
    public static void unsubscribeToActionBtnClicked(Action<ActionInput> action)
    {
        ActionBtnClicked -= action;
    }

    public static void subscribeToConfirmBtnClicked(Action<ConfirmInput> action)
    {
        if (ConfirmBtnClicked == null) _confirmBtnObj.SetActive(true);
        ConfirmBtnClicked += action;
    }
    public static void unsubscribeToConfirmBtnClicked(Action<ConfirmInput> action)
    {
        ConfirmBtnClicked -= action;
        if (ConfirmBtnClicked == null) _confirmBtnObj.SetActive(false);
    }

    public static void registerActionInput(ActionInput actionInput)
    {
        Debug.Log("actionInput has been clicked: " + actionInput._actionBuilder.ToString() + " and " + actionInput.getInputType());
        ActionBtnClicked?.Invoke(actionInput);
        return;
    }   

    public static void registerTileInput(TileInput tileInput)
    {
        TileClicked?.Invoke(tileInput);
        return;
    }

    public static void registerConfirmInput(ConfirmInput confirmInput)
    {
        ConfirmBtnClicked?.Invoke(confirmInput);
        return;
    }
}
