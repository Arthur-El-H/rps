using UnityEngine;

public class ActionInput : IInput
{
    public actionBase action;
    public char getInputType()
    {
        return InputManager.actionClickedType;
    }

}