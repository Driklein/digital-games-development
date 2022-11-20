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

    [SerializeField] private AudioSource jumpSoundEffect;

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
        

        if(Input.GetKeyDown(KeyCode.UpArrow) && onGround==true){
            jumpSoundEffect.Play();
            jumpLimiter = 90;
            move.velocity = Vector2.up * 10;
        }


        if(jumpLimiter>0){
            jumpLimiter--;
            onGround=false;
        }
        else
            onGround = true;


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
