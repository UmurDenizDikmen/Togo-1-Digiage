using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]private GameObject numberPanels;

    private void Start()
    {
        GameManager.onStateChanged += OnStatChanged;
    }
    private void OnStatChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Start:
            numberPanels.SetActive(false);
            break;
            case GameState.InGame:
            numberPanels.SetActive(false);
            break;
            case GameState.Vending:
            numberPanels.SetActive(true);
            break;
        }
    }
}
