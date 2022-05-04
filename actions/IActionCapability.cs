using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionCapability
{
    public IAction getAction();
    public GameObject getActionDisplayObject();
    public void handleInput(IInput input);

}
