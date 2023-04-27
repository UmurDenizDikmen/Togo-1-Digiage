using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachineController : MonoBehaviour
{
    bool isloading = false;
    public Image loadingBarImage;

    private void Start()
    {
          GameManager.onStateChanged += OnStateChanged;
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
    private void OnStateChanged(GameState newState)
    {
        switch(newState)
        {

        }
    }

}
