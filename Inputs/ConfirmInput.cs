using System.Collections.Generic;
using UnityEngine;

public class ConfirmInput : IInput
{
    public static char _type = InputManager.confirmBtnInputType;

    public ConfirmInput()
    {

    }

    public char getInputType()
    {
        return _type;
    }

}