using UnityEngine;

public class ActionInput : IInput
{
    public ActionBase action;
    public char getInputType()
    {
        return InputManager.actionClickedType;
    }
}