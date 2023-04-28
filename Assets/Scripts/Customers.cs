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
    void Start()
    {
        initPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state == GameState.InGame && VendingMachineController.instance.sellableObjects.Count > 0)
        {
            anim.SetBool("isWalk", true);
            agent.SetDestination(vendingLocation.position);
            if (Vector3.Distance(transform.position, vendingLocation.position) < .5f)
            {
                Debug.Log("Umur");
                anim.SetBool("isWalk", false);
                StartCoroutine(SellCustomer());



            }

        }
        else if (Vector3.Distance(transform.position, initPos) < .5f)
        {
            anim.SetBool("isWalk", false);
            anim.transform.rotation = Quaternion.Euler(0,180,0);
        }

    }
    private IEnumerator SellCustomer()
    {
        VendingMachineController.instance.SellObject();
        yield return new WaitForSeconds(1f);
        anim.SetBool("isWalk", true);
        agent.SetDestination(initPos);
    }
}


