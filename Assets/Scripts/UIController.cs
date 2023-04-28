using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]private GameObject numberPanels;
    [SerializeField]private TextMeshProUGUI textMoneyValue;

    private void Start()
    {
        GameManager.onStateChanged += OnStatChanged;
        GameManager.onMoneyChange += OnMoneyChanged;

    }
    private void OnMoneyChanged()
    {
        textMoneyValue.text = GameManager.instance.MoneyValue.ToString();
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
