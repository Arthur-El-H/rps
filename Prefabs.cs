using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    [SerializeField] public GameObject prefab_ActMoveDisplay;
    [SerializeField] public GameObject prefab_ConfirmBtn;


    public static Prefabs Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
