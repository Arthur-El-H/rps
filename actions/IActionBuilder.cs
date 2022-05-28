using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionBuilder 
{
    public void init();
    public void validateActionFinished();
    public IAction getAction();
}
