using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;


public class NavMeshMove : MonoBehaviour {
    
    public Transform destination;

    [SerializeField]
    private GameObject cartContainer;

    [SerializeField]
    private GameObject leftPt;
    [SerializeField]
    private GameObject rightPt;


    
    

    //  public NavMeshAgent navMeshAgent;

    public bool left;
    public bool right;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = 30;
        left = false;
        right = false;
        //navMeshAgent = this.GetComponent<NavMeshAgent>();
        
            SetDestination();
      
	}

    public void Update()
    {
       if(timer <= 0)
        {
            SceneManager.LoadScene("PlayAgain");
        }
        
        if (destination.gameObject.name == "Point37")
        {
            timer -= Time.deltaTime;
            
            GameObject[] holder = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < holder.Length; i++)
            {
                holder[i].GetComponent<WolfSpawner>().maxNumWolf = -1;

            }

            GameObject[] holderW = GameObject.FindGameObjectsWithTag("wContainer");

            for (int i = 0; i < holderW.Length; i++)
            {
                Destroy(holderW[i]);

            }

        }
        else if (right)
        {
            rightPt.GetComponent<SwitchNavDestination>().ChangeDirection(rightPt);
            cartContainer.GetComponent<NavMeshAgent>().SetDestination(rightPt.transform.position);
            right = false;
        }
        else if (left)
        {
            leftPt.GetComponent<SwitchNavDestination>().ChangeDirection(leftPt);
            cartContainer.GetComponent<NavMeshAgent>().SetDestination(leftPt.transform.position);
            left = false;
        }
    }
    private void SetDestination()
    {
        if(destination != null)
        {cartContainer.GetComponent<NavMeshAgent>().ResetPath();
            Vector3 targetVector = destination.transform.position;
            cartContainer.GetComponent<NavMeshAgent>().SetDestination(targetVector);
            
        }
    }

    public void SetDestination(Transform nextPtTransform)
    {
        if (nextPtTransform != null)
        {cartContainer.GetComponent<NavMeshAgent>().ResetPath();
            Debug.Log("destination Point " + nextPtTransform.name);
            Vector3 targetVector = nextPtTransform.transform.position;
            cartContainer.GetComponent<NavMeshAgent>().SetDestination(targetVector);
            destination = nextPtTransform;
            
        }
    }
}
