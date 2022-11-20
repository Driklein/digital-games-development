using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int maxHealth = 100;
    int currentHealth;

    public void takeDamage(int damage){
        currentHealth -= damage;

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Enemy died");
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = maxHealth;
        
    }
}
