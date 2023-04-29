using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class VendingMachineController : MonoBehaviour
{
    bool isloading = false;
    public Image loadingBarImage;
    public int currentOtomatPos;
    public TextMeshProUGUI currentPosNumberText;
    GameManager _gameManager;
    public List<GameObject> sellableObjects = new List<GameObject>();
    public static VendingMachineController instance;
    [SerializeField] private GameObject _boxControl;
    public List<int> otomatAvaliblePos = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<int> removeNumbers = new List<int>();

    [SerializeField] private CinemachineVirtualCamera inVendingCam;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameManager.onStateChanged += OnStateChanged;
        _gameManager = GameManager.instance;

    }
    public void RandomOtomatPos()
    {
        var value = UnityEngine.Random.Range(0, otomatAvaliblePos.Count - 1);
        currentOtomatPos = otomatAvaliblePos[value];
        currentPosNumberText.text = currentOtomatPos.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.carringObjects.Count > 0 && GameManager.instance.state == GameState.InGame)
        {

            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                inVendingCam.Priority = 11;
                _boxControl.SetActive(true);
                GameManager.instance.ChangeGameState(GameState.Vending);
                GameManager.instance.currentVending = transform.gameObject;

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
        _gameManager.MoneyValue += 10;
        otomatAvaliblePos.Add(int.Parse(lastobject.transform.parent.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text));
        removeNumbers.Remove(int.Parse(lastobject.transform.parent.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text));
        Destroy(lastobject);

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
            case GameState.InGame:
                inVendingCam.Priority = 10;
                _boxControl.SetActive(false);
                break;
            case GameState.Vending:

                break;
        }
    }

}
