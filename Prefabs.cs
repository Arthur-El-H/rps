using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    [SerializeField] public GameObject prefab_moveBtn;
    [SerializeField] public GameObject prefab_ConfirmBtn;
    [SerializeField] public GameObject prefab_simpleAttackBtn;
    


    public static Prefabs Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
}
