using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    private int health;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text hitText;

    [SerializeField]
    private GunScript gunScript;

    [SerializeField]
    private Transform cartPos;

    public bool dead;
    private float timer;
    // Use this for initialization
    void Start () {
        timer = 0;
        if(health == 0)
        {
            health = 40;
        }
        dead = false;
        healthText.text = health.ToString();
	}

    private void Update()
    {
        timer -= Time.deltaTime;

        if(this.transform != cartPos.transform) {
            float hold = cartPos.transform.position.y + 1;
            this.transform.position = new Vector3(cartPos.transform.position.x, hold, cartPos.transform.position.z);
        }
        if (Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        if(timer >= 0)
        {
            SceneManager.LoadScene("PlayAgain");
        }
    }



    public void DamagePlayer()
    {
        health -= 10;
        if(health <= 0)
        {
            timer = 30;
            hitText.text = "GAME OVER!";
            hitText.enabled = true;
            dead = true;
            this.transform.parent.transform.parent.GetComponent<NavMeshMove>().SetDestination(this.transform.parent.transform.parent);
         
            gunScript.endGame = true;

            GameObject[] holder = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < holder.Length; i++)
            {
                holder[i].GetComponent<WolfSpawner>().maxNumWolf = -1;

            }

            GameObject[] holderW= GameObject.FindGameObjectsWithTag("wContainer");

            for (int i = 0; i < holderW.Length; i++)
            {
                Destroy(holderW[i]);

            }

            ShowHealth();
            
        }
    }

    public void ShowHealth()
    {
        healthText.text = health.ToString();
    }

}
