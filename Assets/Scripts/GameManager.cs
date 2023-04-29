using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static event Action<GameState> onStateChanged;
    public static event Action onMoneyChange;
    private int money = 50;
    [SerializeField] private CinemachineVirtualCamera inGameCam;
    public List<GameObject> carringObjects = new List<GameObject>();
    public List<GameObject> carriableObjects = new List<GameObject>();
    public GameObject player;
    public static GameManager instance;
    public GameState state { get; private set; }
    public  GameObject currentVending;

    private void Awake()
    {
        instance = this;

    }
    public int MoneyValue
    {
        get { return money; }
        set
        {
            money = value;
            onMoneyChange?.Invoke();
        }
    }
    private void Start()
    {
        ChangeGameState(GameState.Start);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& state == GameState.Start)
        {
            ChangeGameState(GameState.InGame);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            carringObjects.Add(carriableObjects[0].gameObject);
        }
    }
    public void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                inGameCam.Priority = 11;
                break;
            case GameState.InGame:
                inGameCam.Priority = 11;
                player.SetActive(true);
                break;
            case GameState.Vending:
                inGameCam.Priority = 10;
                player.SetActive(false);
            break;
        }
        onStateChanged?.Invoke(newState);
        state = newState;
    }

}
