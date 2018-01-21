using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WolfHealth : MonoBehaviour {

    public int health;
    private int count = 3;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private int destroyPts = 30;

	// Use this for initialization
	void Start () {
        this.GetComponentInChildren<ParticleSystem>().Stop();
        if(health == 0)
        {
            health = 100;
        }
	}

    private void Update()
    {
        this.transform.parent.GetComponent<NavMeshAgent>().SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    public void TakeDamage()
    {
        health -= damage;
        Debug.Log(this.transform.parent.name + " took damage. Their health is: " + health);

        GameObject player = GameObject.Find("Rifle-Enfield");
        if (health <= 0)
        {
            Debug.Log(this.transform.parent.name + " died!");
            Destroy(this.transform.parent.gameObject);
            player.GetComponent<GunScript>().AddPoints(destroyPts);
        }
        else
        {
            player.GetComponent<GunScript>().AddPoints(damage);
        }

        this.GetComponentInChildren<ParticleSystem>().Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DamagePlayer();
        }
    }

    //public void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        if(this.GetComponent<MeshCollider>().enabled == true)
    //        {
    //            this.GetComponent<MeshCollider>().enabled = false;
    //        }
    //        else if(this.GetComponent<MeshCollider>().enabled == false){
    //             this.GetComponent<MeshCollider>().enabled = true;
    //        }
            
    //    }
   // }
}
