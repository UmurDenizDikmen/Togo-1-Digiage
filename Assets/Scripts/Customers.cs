using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Customers : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Transform vendingLocation;
    [SerializeField] GameObject vendingMachine;
    public Animator anim;
    Vector3 initPos;
    bool isSelling = false;
    bool isReturn = false;

    void Start()
    {
        initPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state == GameState.InGame && VendingMachineController.instance.sellableObjects.Count > 0 && isReturn == false)
        {
            anim.SetBool("isWalk", true);
            if(isSelling == false)
            {
                agent.SetDestination(vendingLocation.position);
            }

            if (Vector3.Distance(transform.position, vendingLocation.position) < .5f && !isSelling)
            {

                anim.SetBool("isWalk", false);
                isSelling = true;
                VendingMachineController.instance.SellObject();
                anim.SetBool("isWalk", true);
                agent.SetDestination(initPos);
                Debug.Log("0");
                isReturn = true;
            }

         }
        else if (Vector3.Distance(transform.position, initPos) < .5f&&isReturn)
        {
            anim.SetBool("isWalk", false);
            anim.transform.rotation = Quaternion.Euler(0, 180, 0);
            isSelling = false;
            isReturn = false;
            Debug.Log("1");
        }

    }
    /*private IEnumerator SellCustomer()
    {
        isSelling = true;
        VendingMachineController.instance.SellObject();
        yield return new WaitForSeconds(2f);
        anim.SetBool("isWalk", true);
        agent.SetDestination(initPos);


    }*/
}


