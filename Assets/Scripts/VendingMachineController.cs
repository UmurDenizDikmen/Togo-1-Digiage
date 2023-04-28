using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachineController : MonoBehaviour
{
    bool isloading = false;
    public Image loadingBarImage;
    GameManager _gameManager;
    public List<GameObject> sellableObjects = new List<GameObject>();
    public static VendingMachineController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameManager.onStateChanged += OnStateChanged;
        _gameManager = GameManager.instance;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.carringObjects.Count > 0 && GameManager.instance.state == GameState.InGame)
        {

            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                //GameManager.instance.objectsBox.SetActive(true);
                GameManager.instance.ChangeGameState(GameState.Vending);
            }
        }
    }
    public void SellableObjectAdd(GameObject obj)
    {

        sellableObjects.Add(obj);
    }
    public void SellObject()
    {
        if (sellableObjects.Count == 0) return;
        var lastobject = sellableObjects[0];
        sellableObjects.RemoveAt(0);
        Destroy(lastobject);
        _gameManager.MoneyValue += 10;
      //  _gameManager.otomatAvaliblePos.Add(int.Parse(lastobject.transform.parent.GetComponent<TextMeshPro>().text));
       // _gameManager.removeNumbers.Remove(int.Parse(lastobject.transform.parent.GetComponent<TextMeshPro>().text));

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            loadingBarImage.fillAmount = 0;
        }

    }
    private void OnStateChanged(GameState newState)
    {
        switch (newState)
        {

        }
    }

}
