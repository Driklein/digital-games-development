using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource blockSoundEffect;

    void Attack(){
        animator.SetTrigger("isAttacking");
    }
    void Block(){
        animator.SetTrigger("isBlocking");
    }
    // Update is called once per frame
    void onDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.X)){
            Attack();
            attackSoundEffect.Play();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            Block();
            blockSoundEffect.Play();
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }
        
    }
    
}
