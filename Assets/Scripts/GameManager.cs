using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List <int> otomatAvaliblePos = new List<int>{1,2,3,4,5,6,7,8,9};
    public List <int> removeNumbers = new List<int>(); //bunu yapay zaeka oldugu zaman otomat lsitesine tekrar eklicez.
    public List <GameObject> carringObjects = new List<GameObject>();
    public List <GameObject> carriableObjects = new List<GameObject>();
    public int currentOtomatPos;
    public TextMeshProUGUI currentPosNumberText;
    public static GameManager instance;

    private void  Awake()
    {
        instance = this;
    }
    public void RandomOtomatPos()
    {
        currentOtomatPos = UnityEngine.Random.Range(1,otomatAvaliblePos.Count);
        currentPosNumberText.text = currentOtomatPos.ToString();
    }
}
