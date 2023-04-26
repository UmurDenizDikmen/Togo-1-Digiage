using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour
{
    GameManager gameManager;
    private Vector3 offset;
    private Transform parent;
    private Vector3 initPos;
    private bool isInPlace = false;

    public enum typeOfItem
    {
        waterBottle,
        cips,
        cola,
    }
    private void Start()
    {
        initPos = transform.position;
        gameManager = GameManager.instance;
    }
    public typeOfItem itemType;
    private void OnMouseDown()
    {
        gameManager.RandomOtomatPos();
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        initPos = transform.position;
        parent = transform.parent;

    }
    private void OnMouseDrag()
    {
        Vector3 currentPos = MouseWorldPosition() + offset;
        float ypos = currentPos.y;
        currentPos.y = Mathf.Clamp(ypos,4f,10f);
        transform.position = new Vector3(-5.5f,  currentPos.y , currentPos.z);
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

    }
    private void OnMouseUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .7f);
        foreach (var hit in hitColliders)
        {

            var hitNumber = int.Parse(hit.transform.GetChild(0).GetComponent<TextMeshPro>().text);
            if (hitNumber == gameManager.currentOtomatPos)
            {

                var transformRaf = hit.transform.GetChild(1);
                transform.SetParent(transformRaf);
                transform.position = transformRaf.position;
                isInPlace = true;
                gameManager.otomatAvaliblePos.Remove(gameManager.currentOtomatPos); //burda ana listeden çıkardık  //burda kmerata hareketini kontrol edicez.
                gameManager.removeNumbers.Add(gameManager.currentOtomatPos); // diğer lsiteye ekledik.
                gameManager.currentPosNumberText.text = string.Empty;
                gameManager.carringObjects.Remove(transform.gameObject);
            }
        }
        if (isInPlace == false)
        {
            transform.position = initPos;
            transform.SetParent(parent);
            transform.GetComponent<Collider>().enabled = true;
        }


    }
    private void OnDrawGizmos()
    {
          Gizmos.color = Color.red;
          Gizmos.DrawWireSphere(transform.position,.7f);
    }
    private Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
