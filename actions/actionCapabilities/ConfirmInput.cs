using System.Collections.Generic;
using UnityEngine;

public class ConfirmInput : IInput
{
    public IAction _action;
    public static char _type = 'c';

    public ConfirmInput()
    {

    }

    public char getInputType()
    {
        return _type;
    }

}