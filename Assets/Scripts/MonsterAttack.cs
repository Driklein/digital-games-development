using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;

    

    public LayerMask whatIsEnemies;
    public Animator monsterAnim;
    public int damage;

    

    // Update is called once per frame
    void Start(){
        damage = 20;
    }
    
    void Update()
    {

        if(timeBtwAttack <= 0){
            timeBtwAttack = startTimeBtwAttack;

            monsterAnim.SetTrigger("isAttacking");
            

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            
            for(int i=0; i<enemiesToDamage.Length; i++){

                if(enemiesToDamage[i].GetComponent<PlayerAttack>().ReturnBlock()){
                    break;
                }

                enemiesToDamage[i].GetComponent<Soldier>().TakeDamage(damage);
            }

            timeBtwAttack = startTimeBtwAttack;

            
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;   
        Gizmos.DrawWireSphere(attackPos.position, attackRange);     
    }

}
