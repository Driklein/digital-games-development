using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersScene : MonoBehaviour
{
    
    public Rigidbody2D move;
    public int moveSpeed;
    public float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    private bool onGround;
    private int jumpLimiter;
    private bool canAct;
    private int actionLimiter;
    public Animator animator;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        move = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        moveSpeed = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
         if(direction!=0){
            animator.SetBool("isMoving",true);
        }
        else
            animator.SetBool("isMoving",false);

        
        if(i>700 && i<850){
            //monstros entram
            direction = -1;
        }
        if(i>850 && i<1100){
            direction=0;
        // Monstros?
        }
        if(i>1100 && i<1200){
           //monstros atacam
           if(i%30==0) 
           animator.SetTrigger("isAttacking");  
        }
        if(i>1200 && i<1400){
            direction = -1;
        }
        if(i>1400){
            direction = 1;
        }

        i++;


        if(direction < 0){
            transform.localScale = facingRight;
        }
        if(direction > 0){
            transform.localScale = facingLeft;
        }
        
        move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);
    }
}
