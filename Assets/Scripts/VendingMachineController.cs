using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachineController : MonoBehaviour
{
    bool isloading = false;
    public Image loadingBarImage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // StartCoroutine(LoadingBar(loadingBarImage,1f,Time.time));
            loadingBarImage.fillAmount += .8f * Time.deltaTime;
            if (loadingBarImage.fillAmount == 1)
            {
                //işlem yap
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
    /*private IEnumerator LoadingBar(Image loadingBar, float waitTime, float startTime)
    {
        isloading = true;
        print(startTime);
        print($"basladi: {Time.deltaTime}");
        while (startTime + waitTime >= Time.time)
        {
            print($"baslama: {Time.deltaTime}");
            loadingBar.fillAmount += 1f/1f*Time.deltaTime;
            yield return null;

        }
        loadingBar.fillAmount = 0f;
        print($"bitti: {Time.deltaTime}");
        isloading = false;
    }*/
}
