using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public Animator playerAnim;
    public int damage;

    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource blockSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0 ){
            timeBtwAttack = startTimeBtwAttack;

            if(Input.GetKey(KeyCode.K)){
                
                playerAnim.SetTrigger("isAttacking");
                attackSoundEffect.Play();

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i=0; i<enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Monsters>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.J)){
            playerAnim.SetTrigger("isBlocking");
            blockSoundEffect.Play();
        }
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
