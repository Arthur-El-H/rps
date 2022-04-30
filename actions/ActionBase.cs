using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract Task Act();
}
