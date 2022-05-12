using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCapabilityFactory : MonoBehaviour
{
    public static MoveActionCapability getMoveActionCapability()
    {
        return new MoveActionCapability();
    }
}
