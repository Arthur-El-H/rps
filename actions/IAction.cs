using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IAction
{
    //public abstract Task Act();
    public Task act();
    public int halfToStartAt();
}

