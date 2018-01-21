using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {
   
    public float range = 100f;
    [SerializeField]
    private int score;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text hitText;

    private float timer = .5f;
    public Camera fpsCam;
    [SerializeField]
    private GameObject cart;


    public bool endGame;

    private void Start()
    {
        hitText.enabled = false;
        endGame = false;
    }
    private void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            // call shooting code
            Shoot();
        }

        if(timer <= 0)
        {
            timer = .5f;
            
                hitText.enabled = false;
         
        }

        if (endGame)
        {
            timer = 99999999999;
        }
    }

    private void Shoot()
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponentInChildren<ParticleSystem>().Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Just hit the " + hit.transform.name);
            if (hit.transform.name == "green arrow")
            {
                Debug.Log("Just hit the " + hit.transform.name);

                cart.GetComponent<NavMeshMove>().left = true;
            }
            else if(hit.transform.name == "yellowarrow")
            {
                Debug.Log("Just hit the " + hit.transform.name);
                cart.GetComponent<NavMeshMove>().right = true;
            }
            else if (hit.transform.tag == "Wolf")
            {
                Debug.Log("Just hit the " + hit.transform.name);
                hit.transform.GetComponent<WolfHealth>().TakeDamage();
                timer -= Time.deltaTime;
                if (hitText.enabled == false)
                {
                    hitText.enabled = true;

                }
            }
            else if(hitText.text == "GAME OVER!")
            {
                hitText.enabled = true;

                
            }

            else
            {
                hitText.enabled = false;
            }
            cart.GetComponent<NavMeshAgent>().enabled = true;
            
        }
    }


    public void AddPoints(int inScore)
    {
        score += inScore;
        scoreText.text = score.ToString();

        if(inScore > 10)
        {
            hitText.text = "Got one!";
        }
        else
        {
            hitText.text = "Hit!";
        }
        
    }
}
