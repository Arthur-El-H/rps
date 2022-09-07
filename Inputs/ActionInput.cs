using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : IInput
{
    public const char _type = InputManager.actionInputType;
    public IActionBuilder _actionBuilder;

    public ActionInput(IActionBuilder actionBuilder)
    {
        _actionBuilder = actionBuilder;
    }

    public char getInputType()
    {
        return _type;
    }
}
