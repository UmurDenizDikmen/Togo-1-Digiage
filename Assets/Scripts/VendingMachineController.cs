using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachineController : MonoBehaviour
{
    GameManager _gameManager;
    bool isloading = false;
    public Image loadingBarImage;
    public GameObject moneyPopup;
    public int sellableObjectCount = 0;
    public List<GameObject> sellableObjects = new List<GameObject>();

    private void Start()
    {
        GameManager.onStateChanged += OnStateChanged;
        _gameManager = GameManager.instance;
        //InvokeRepeating("SellObject",1f,2f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&& GameManager.instance.carringObjects.Count > 0 && GameManager.instance.state == GameState.InGame)
        {

            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                //GameManager.instance.objectsBox.SetActive(true);
                GameManager.instance.ChangeGameState(GameState.Vending);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            loadingBarImage.fillAmount = 0;
        }

    }
    public void SellableObjectAdd(GameObject obj)
    {
        //sellableObjectCount++;
        Debug.Log("obje eklendi");
        sellableObjects.Add(obj);
    }
    public void SellObject()
    {
        Debug.Log("satis basladi");
        if(sellableObjects.Count==0) return;
        var lastobject =sellableObjects[0];
        sellableObjects.RemoveAt(0);
        Destroy(lastobject);
        _gameManager.MoneyValue+=10;
        Debug.Log("satis oldu");
    }
    private void OnStateChanged(GameState newState)
    {
        switch(newState)
        {

        }
    }

}
