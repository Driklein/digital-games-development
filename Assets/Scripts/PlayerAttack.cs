using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

    public Animator playerAnim;
    public bool isBlocking;

    public int damage;

    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource blockSoundEffect;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public bool returnBlock(){
        return isBlocking;
    }


    void Update()
    {
        if(timeBtwAttack <= 0){

            if(Input.GetKey(KeyCode.K)){

                playerAnim.SetTrigger("isAttacking");
                attackSoundEffect.Play();

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for(int i=0; i<enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Monsters>().TakeDamage(damage);
                }
                
            }
            

            timeBtwAttack = startTimeBtwAttack;

        }else{
            timeBtwAttack -= Time.deltaTime;
        }
    

        if(Input.GetKeyDown(KeyCode.J)){
            playerAnim.SetBool("isBlocking",true);
            blockSoundEffect.Play();
            isBlocking=true;
            Debug.Log("is blocking");
        }
        if(Input.GetKeyUp(KeyCode.J)){
            playerAnim.SetBool("isBlocking",false);
            blockSoundEffect.Play();
            isBlocking=false;
            Debug.Log("is not blocking");
        }
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color=Color.red;   
        Gizmos.DrawWireSphere(attackPos.position, attackRange);     
    }

}


