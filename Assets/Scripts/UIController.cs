using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject numberPanels;
    [SerializeField] private GameObject moneyPanels;
    [SerializeField] private TextMeshProUGUI textMoneyValue;

    private void Start()
    {
        GameManager.onStateChanged += OnStatChanged;
        GameManager.onMoneyChange += OnMoneyChanged;
        textMoneyValue.text = GameManager.instance.MoneyValue.ToString();

    }
    private void OnMoneyChanged()
    {
        textMoneyValue.text = GameManager.instance.MoneyValue.ToString();
    }
    private void OnStatChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                numberPanels.SetActive(false);
                moneyPanels.SetActive(true);
                break;
            case GameState.InGame:
                numberPanels.SetActive(false);
                moneyPanels.SetActive(true);
                break;
            case GameState.Vending:
                numberPanels.SetActive(true);
                moneyPanels.SetActive(false);
                break;
        }
    }
}
