using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SwitchNavDestination : MonoBehaviour {
    [SerializeField]
    private GameObject nextPt;

    [SerializeField]
    private GameObject cart;

    

	private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "MineCart")
        {
            Debug.Log("In On trigger enter " + this.name);
            if (cart.GetComponent<NavMeshAgent>().enabled == false)
            {
                cart.GetComponent<NavMeshAgent>().enabled = true;
            }
            
            cart.GetComponent<NavMeshMove>().SetDestination(nextPt.transform);
        }
        
    }

    public void ChangeDirection(GameObject newDirection)
    {
        cart.GetComponent<NavMeshAgent>().enabled = true;
        cart.GetComponent<NavMeshMove>().SetDestination(newDirection.transform);
    }
}
