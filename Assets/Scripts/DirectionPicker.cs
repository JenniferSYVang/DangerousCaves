using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DirectionPicker : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent cart;
    [SerializeField]
    private Text question;

    [SerializeField]
    private GameObject leftarrow;
    [SerializeField]
    private GameObject rightarrow;

    private void Start()
    {
        question.enabled = false;
        leftarrow.GetComponent<BoxCollider>().enabled = false;
        leftarrow.GetComponent<MeshRenderer>().enabled = false;
        rightarrow.GetComponent<BoxCollider>().enabled = false;
        rightarrow.GetComponent<MeshRenderer>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        leftarrow.GetComponent<BoxCollider>().enabled = true;
        leftarrow.GetComponent<MeshRenderer>().enabled = true;
        rightarrow.GetComponent<BoxCollider>().enabled = true;
        rightarrow.GetComponent<MeshRenderer>().enabled = true;

        if (other.tag == "MineCart")
        {
            question.enabled = true;
            cart.enabled = false;

            GameObject[] holder = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < holder.Length; i++)
            {
                holder[i].GetComponent<WolfSpawner>().maxNumWolf = -1;

            }


            GameObject[] holderW = GameObject.FindGameObjectsWithTag("wContainer");

            for (int i = 0; i < holderW.Length; i++)
            {
                holderW[i].GetComponent<NavMeshAgent>().Stop();

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        leftarrow.GetComponent<BoxCollider>().enabled = false;
        leftarrow.GetComponent<MeshRenderer>().enabled = false;
        rightarrow.GetComponent<BoxCollider>().enabled = false;
        rightarrow.GetComponent<MeshRenderer>().enabled = false;

        question.enabled = false;
        GameObject[] holderW = GameObject.FindGameObjectsWithTag("wContainer");

        for (int i = 0; i < holderW.Length; i++)
        {
            holderW[i].GetComponent<NavMeshAgent>().Resume();

        }

        GameObject[] holder = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = 0; i < holder.Length; i++)
        {
            holder[i].GetComponent<WolfSpawner>().maxNumWolf = 15;

        }
    }
}
