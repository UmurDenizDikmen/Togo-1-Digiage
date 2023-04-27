using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public Image loadingBarImage;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&& GameManager.instance.carringObjects.Count < 5 && GameManager.instance.state == GameState.InGame)
        {

            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                _gameManager.carringObjects.Add(_gameManager.carriableObjects[Random.Range(0,_gameManager.carriableObjects.Count)]);
                loadingBarImage.fillAmount = 0;
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
}
