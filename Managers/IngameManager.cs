using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] private Map _map;

    [SerializeField] public GameObject _pref_player;
    [SerializeField] int _amountOfPlayers = 2;
    private IMatchManager matchManager;

    void Start()
    {
        matchManager = new MatchManagerStandart(_amountOfPlayers);
        Application.targetFrameRate = 30;
    }
}