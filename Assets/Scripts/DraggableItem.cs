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
    private VendingMachineController vendingController;

    public enum typeOfItem
    {
        waterBottle,
        cips,
        cola,
    }
    private void Start()
    {
        initPos = transform.localPosition;
        gameManager = GameManager.instance;
    }
    public typeOfItem itemType;
    private void OnMouseDown()
    {
        vendingController = GameManager.instance.currentVending.GetComponent<VendingMachineController>();
        vendingController.RandomOtomatPos();
        offset = transform.localPosition - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        initPos = transform.localPosition;
        parent = transform.parent;

    }
    private void OnMouseDrag()
    {
        Vector3 currentPos = MouseWorldPosition() + offset;
        // float ypos = currentPos.y;
        // currentPos.y = Mathf.Clamp(ypos,3f,1.2f);
        transform.localPosition = new Vector3(currentPos.x, currentPos.y, 1.2f);
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

    }
    private void OnMouseUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .2f, 1 << 7);
        foreach (Collider hit in hitColliders)
        {
            var hitNumber = hit.transform.GetChild(0).GetComponent<TextMeshPro>().text;
            var mainParent = hit.transform.root;
           // vendingController = mainParent.GetComponent<VendingMachineController>();
            var numberOfItem = int.Parse(hitNumber);


            if (numberOfItem == vendingController.currentOtomatPos && hitNumber != null)
            {
                BoxController.isSelected = false;
                var transformRaf = hit.transform.GetChild(1);
                transform.SetParent(transformRaf);
                transform.position = transformRaf.position;
                isInPlace = true;
                vendingController.otomatAvaliblePos.Remove(vendingController.currentOtomatPos); //burda ana listeden çıkardık
                vendingController.removeNumbers.Add(vendingController.currentOtomatPos); // diğer lsiteye ekledik.
                vendingController.currentPosNumberText.text = string.Empty;
                // gameManager.carringObjects.Remove(transform.gameObject);
                gameManager.carringObjects.RemoveAt(gameManager.carringObjects.Count - 1);
                hit.transform.parent.GetComponent<VendingMachineController>().SellableObjectAdd(transform.gameObject);
                if (gameManager.carringObjects.Count == 0 || vendingController.otomatAvaliblePos.Count == 0)
                {
                    gameManager.ChangeGameState(GameState.InGame);
                }
            }
            if (hit == null)
            {
                transform.localPosition = initPos;
                transform.SetParent(parent);
                transform.GetComponent<Collider>().enabled = true;
            }



        }
        if (isInPlace == false)
        {
            transform.localPosition = initPos;
            transform.SetParent(parent);
            transform.GetComponent<Collider>().enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, .2f);
    }
    private Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
