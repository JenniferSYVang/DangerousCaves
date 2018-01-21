using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour {
    [SerializeField]
    private float timer;
    private float tHolder;
    [SerializeField]
    private GameObject spawnPt;

    [SerializeField]
    private GameObject wolf;

    [SerializeField]
    private PlayerHealth playerHealth;

    public int maxNumWolf;

    private bool stop;


    private void Start()
    {
        stop = false;

        if(timer == 0)
        {
            timer = 2;
        }

        if(maxNumWolf == 0)
        {
            maxNumWolf = 15;
        }
        tHolder = timer;
    }

    public void OnTriggerStay(Collider other )
    {
        if(stop == false && other.tag == "MineCart" || other.tag == "Player")
        {
            while(timer <= 0)
            {
                Debug.Log(timer);

                if(GameObject.FindGameObjectsWithTag("Wolf").Length <= maxNumWolf )
                {
                    Debug.Log("Creating a wolf");
                    Instantiate(wolf, spawnPt.transform);
                    timer = tHolder;

                }
                
                timer = tHolder;
            }
        }
        timer -= Time.deltaTime;
    }

}
