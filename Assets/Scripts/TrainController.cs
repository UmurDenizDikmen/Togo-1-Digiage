using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TrainMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TrainMove()
    {
        transform.DOMoveX(90,4f).SetEase(Ease.InOutSine).SetLoops(4,LoopType.Yoyo).OnComplete(()=>
            transform.DOMoveX(55,2f).SetEase(Ease.InOutSine).OnComplete(()=>
                transform.DOMoveX(55,3f).SetEase(Ease.InOutSine).OnComplete(()=>
                    transform.DOMoveX(90,2f).SetEase(Ease.InOutSine).OnComplete(()=>
                        transform.DOMoveX(20,4f).SetEase(Ease.InOutSine).OnComplete(()=>
                            TrainMove()
                        )
                    )
                )
            )
        );     
    }
}
