using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for(int i=0; i<enemiesToDamage.Length; i++){
            enemiesToDamage[i].GetComponent<Soldier>().LifePotion();
            this.gameObject.SetActive(false);
        }

        
        
    }
}
