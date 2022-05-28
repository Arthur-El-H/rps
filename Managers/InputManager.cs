using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public const char actionInputType = 'a';
    public const char tileInputType = 'b';

    public const char confirmBtnInputType = 'c';
    public const char backBtnInputType = 'd';
    public const char enterBtnInputType = 'e';

    public static Action<TileInput> TileClicked;
    public static Action<ActionInput> ActionBtnClicked;
    public static Action<ConfirmInput> ConfirmBtnClicked;

    public void subscribeToTileClicked(Action<TileInput> action)
    {
        TileClicked += action;
    }
    public void unsubscribeToTileClicked(Action<TileInput> action)
    {
        TileClicked -= action;
    }

    public void subscribeToActionBtnClicked(Action<ActionInput> action)
    {
        ActionBtnClicked += action;
    }
    public void unsubscribeToActionBtnClicked(Action<ActionInput> action)
    {
        ActionBtnClicked -= action;
    }

    public void subscribeToConfirmBtnClicked(Action<ConfirmInput> action)
    {
        // TODO Show btn when more than one is subscribed
        ConfirmBtnClicked += action;
    }
    public void unsubscribeToConfirmBtnClicked(Action<ConfirmInput> action)
    {
        ConfirmBtnClicked -= action;
        // TODO hide button when empy
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
