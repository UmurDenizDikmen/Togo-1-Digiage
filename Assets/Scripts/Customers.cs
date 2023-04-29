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
    private Vector3 initPos;
    private bool isSelling = false;
    private bool isReturn = false;

    private void Start()
    {
        initPos = transform.position;

    }
    private void Update()
    {
        if (GameManager.instance.state == GameState.InGame && VendingMachineController.instance.sellableObjects.Count > 0 && !isReturn)
        {
            anim.SetBool("isWalk", true);
            if (isSelling == false)
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
                isReturn = true;
            }

        }
        else if (Vector3.Distance(transform.position, initPos) < .5f && isReturn)
        {
            anim.SetBool("isWalk", false);
            anim.transform.rotation = Quaternion.Euler(0, 180, 0);
            isSelling = false;
            isReturn = false;

        }
        else if (GameManager.instance.state == GameState.Vending)
        {
            anim.SetBool("isWalk", true);
            agent.SetDestination(initPos);
            if(Vector3.Distance(transform.position, initPos) < .5f)
            {
                anim.SetBool("isWalk", false);
               anim.transform.rotation = Quaternion.Euler(0, 180, 0);
                isReturn = true;
            }

        }


    }

}