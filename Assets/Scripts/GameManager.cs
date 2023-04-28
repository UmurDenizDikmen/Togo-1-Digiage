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
    public List<int> otomatAvaliblePos = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> removeNumbers = new List<int>(); //bunu yapay zaeka oldugu zaman otomat lsitesine tekrar eklicez.
    [SerializeField] private CinemachineVirtualCamera inGameCam;
    [SerializeField] private CinemachineVirtualCamera inVendingCam;
    public List<GameObject> carringObjects = new List<GameObject>();
    public List<GameObject> carriableObjects = new List<GameObject>();
    public int currentOtomatPos;
    public TextMeshProUGUI currentPosNumberText;
    public GameObject objectsBox,player;
    public static GameManager instance;
    public GameState state { get; private set; }

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
    public void RandomOtomatPos()
    {
        var value = UnityEngine.Random.Range(0, otomatAvaliblePos.Count - 1);
        currentOtomatPos = otomatAvaliblePos[value];
        currentPosNumberText.text = currentOtomatPos.ToString();
    }
    void Update()
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
                inVendingCam.Priority = 10;
                break;
            case GameState.InGame:
                inGameCam.Priority = 11;
                inVendingCam.Priority = 10;
                objectsBox.SetActive(false);
                player.SetActive(true);
                break;
            case GameState.Vending:
                inGameCam.Priority = 10;
                inVendingCam.Priority = 11;
                objectsBox.SetActive(true);
                player.SetActive(false);

                break;
        }
        onStateChanged?.Invoke(newState);
        state = newState;
    }

}
