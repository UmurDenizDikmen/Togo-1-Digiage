using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StoreController : MonoBehaviour
{
    public Image loadingBarImage;
    public Transform boxPoint,storePoint;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameManager.instance;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && _gameManager.carringObjects.Count < BoxController.maxCapacity && _gameManager.state == GameState.InGame)
        {
            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                var currentObject = _gameManager.carriableObjects[Random.Range(0,_gameManager.carriableObjects.Count)];
                _gameManager.carringObjects.Add(currentObject);
                var instantiateObject = Instantiate(currentObject,storePoint.position,Quaternion.identity);
                instantiateObject.transform.DOJump(boxPoint.position,1,1,1f).SetEase(Ease.Linear).OnComplete(()=>Destroy(instantiateObject));
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
