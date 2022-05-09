using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionCapability
{
    public GameObject getActionDisplayObject();

    public void setInputManager(InputManager inputManager);
    public void createAction(PlayerTurnBuilder playerTurnBuilder);

}
