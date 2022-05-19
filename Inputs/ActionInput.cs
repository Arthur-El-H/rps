using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : IInput
{
    public const char _type = InputManager.actionInputType;
    public IActionBuilder _actionBuilder;

    public ActionInput(Move_Builder moveActionBuilder)
    {
        _actionBuilder = moveActionBuilder;
    }

    public char getInputType()
    {
        return _type;
    }
}
