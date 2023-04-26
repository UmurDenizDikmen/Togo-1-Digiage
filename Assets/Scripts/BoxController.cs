using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameManager _gameManager;
    private int maxCapacity = 3;
    private GameObject objects;
    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager.carringObjects.Capacity = maxCapacity;
    }
    private void OnMouseDown()
    {
        int randomObjects = Random.Range(0, maxCapacity-1);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           var type = _gameManager.carringObjects[randomObjects].GetComponent<DraggableItem>().itemType;
           switch(type)
           {
               case DraggableItem.typeOfItem.waterBottle :
                 objects =   Instantiate(_gameManager.carriableObjects[0],hit.point,Quaternion.identity);
               break;
                 case DraggableItem.typeOfItem.cips :
                 objects =   Instantiate(_gameManager.carriableObjects[1],hit.point,Quaternion.identity);
               break;
                 case DraggableItem.typeOfItem.cola :
                 objects =   Instantiate(_gameManager.carriableObjects[2],hit.point,Quaternion.identity);
               break;
           }

             objects.transform.SetParent(transform);
            objects.transform.DOScale(new Vector3(0.2f,0.2f,0.2f),0.01f);
            _gameManager.carringObjects.Remove(objects);

        }



    }
}
