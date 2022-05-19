using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionBuilder 
{
    public void handleInput(IInput input);
    public void validateActionFinished();
    public IAction getAction();
}
