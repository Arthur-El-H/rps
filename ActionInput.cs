using UnityEngine;

public class ActionInput : IInput
{
    public IAction action;
    public char getInputType()
    {
        return InputManager.actionClickedType;
    }
}