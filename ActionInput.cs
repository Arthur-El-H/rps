using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : IInput
{
    public const char _type = 'b';
    public IActionCapability _actionCapability;

    public char getInputType()
    {
        return _type;
    }
}
