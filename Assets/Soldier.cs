using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        move = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = 5;
        jumpLimiter = 0;
        actionLimiter = 0;
        canAct = true;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")!=0){
            animator.SetBool("isWalking",true);
        }
        else
            animator.SetBool("isWalking",false);
        

        if(Input.GetKey("i") && canAct==true){
            actionLimiter = 40;
            canAct = false;
            animator.SetBool("isAttacking",true);
        }
        else
            animator.SetBool("isAttacking",false);
        

        if(Input.GetKey("o") && canAct==true){
            animator.SetBool("isBlocking",true);
        }
        else
            animator.SetBool("isBlocking",false);
        

        if(Input.GetKeyDown("space") && onGround==true){
            jumpLimiter = 90;
            move.velocity = Vector2.up * 10;
        }


        if(jumpLimiter>0){
            jumpLimiter--;
            onGround=false;
        }
        else
            onGround = true;

        if(actionLimiter>0){
            actionLimiter--;
            canAct=false;
        }
        else
            canAct= true;

        direction = Input.GetAxis("Horizontal");  
        move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);

        if(direction > 0){
            transform.localScale = facingRight;
        }
        if(direction < 0){
            transform.localScale = facingLeft;
        }
    }
}
