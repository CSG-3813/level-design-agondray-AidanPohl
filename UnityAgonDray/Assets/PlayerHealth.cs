using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public int maxHealth = 20;
    public int health;
    public float regenCooldown = 5f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        InvokeRepeating("Regen", regenCooldown, regenCooldown);//sets up health regen
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Regen()//regenerates health
    {
        health++;
        if (health > maxHealth) { health = maxHealth; }//health overflow
    }

    public void Damage(int damage)
    {
        health -= damage;
        HealthCheck();
    }

    void HealthCheck()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("LigthingFurnature");
        }
    }
}
