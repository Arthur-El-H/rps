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



    public static void registerActionInput(ActionInput actionInput)
    {
        Debug.Log("actionInput has been clicked: " + actionInput._actionBuilder.ToString() + " and " + actionInput.getInputType());
        ActionBtnClicked.Invoke(actionInput);
        return;
    }

    public static void registerTileInput(TileInput tileInput)
    {
        TileClicked.Invoke(tileInput);
        return;
    }

    public static void registerConfirmInput(ConfirmInput confirmInput)
    {
        ConfirmBtnClicked.Invoke(confirmInput);
        return;
    }
}
