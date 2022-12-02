using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene : MonoBehaviour
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
   
    public GameObject D1;
    public GameObject D2;
    public GameObject D3;
    public GameObject D4;
    // Start is called before the first frame update
    void Start()
    {

        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        move = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        moveSpeed = 3;
        jumpLimiter = 0;
        onGround = true;
        i=0;

        D1.SetActive(false);
        D2.SetActive(false);
        D3.SetActive(false);
        D4.SetActive(false);


        
    }

    // Update is called once per frame
    void Update()
    {

        if(direction!=0){
            animator.SetBool("isWalking",true);
        }
        else
            animator.SetBool("isWalking",false);

        if(i>100 && i<300)
            D1.SetActive(true); // Hoje foi um longo dia

        if(i>300 && i<400){
            D1.SetActive(false);
            direction = 1;
        }
        if(i>400 && i<700){
            direction = 0;
            D2.SetActive(true);    // Vamos voltando
        }
        if(i>700 && i<800){
            D2.SetActive(false);
        }
        if(i>800 && i<1000){
            D3.SetActive(true);   // Monstros?
        }
        if(i>1000 && i<1100){
            //moveSpeed=5;
            D3.SetActive(false);
            direction = 1;
        }
        if(i>1100 && i<1200){
            direction=0;
            if(i%30==0)
                animator.SetTrigger("isAttacking");
        }
        if(i>1200 && i<1800){
            animator.SetBool("isDying",true);
        }
        if(i>1800 && i<2000){
            animator.SetBool("isDying",false);
            D4.SetActive(true);
        }
        if(i>2000){
            direction = 1;
            D4.SetActive(false);
        }

        if(i==2500)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

        i++;

        move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);

        if(direction > 0){
            transform.localScale = facingRight;
        }
        if(direction < 0){
            transform.localScale = facingLeft;
        }
        
    }
}
