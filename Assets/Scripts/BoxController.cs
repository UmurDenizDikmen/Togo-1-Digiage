using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameManager _gameManager;
    private int maxCapacity = 3;
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
            var objects =   Instantiate(_gameManager.carringObjects[randomObjects],hit.point,Quaternion.identity);
            objects.transform.SetParent(transform);
            objects.transform.DOScale(new Vector3(0.2f,0.2f,0.2f),0.01f);
            _gameManager.carringObjects.Remove(objects);

        }



    }
}
