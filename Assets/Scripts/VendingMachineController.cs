using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VendingMachineController : MonoBehaviour
{
    bool isloading = false;
    public Image loadingBarImage, loadingBarBackgroundImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LoadingBar(loadingBarImage,loadingBarBackgroundImage,1f,Time.time));
        }
    }
    IEnumerator LoadingBar(Image loadingBar, Image loadingBarBackground, float waitTime, float startTime)
    {
        isloading = true;
        print(startTime);
        print($"basladi: {Time.deltaTime}");        
        while (startTime + waitTime >= Time.time)
        {
            print($"baslama: {Time.deltaTime}");
            loadingBarBackground.fillAmount -= 1f/1f*Time.deltaTime;
            loadingBar.fillAmount += 1f/1f*Time.deltaTime;
            yield return null;
        }
        loadingBar.fillAmount = 0f;
        loadingBarBackground.fillAmount = 1f;
        print($"bitti: {Time.deltaTime}");
        isloading = false;
    }
}
