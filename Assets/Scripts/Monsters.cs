using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour
{
    public Rigidbody2D move;
    public int moveSpeed;
    public float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public Animator animator;
    private bool alive;
    private bool isMoving;
    private int x_controller;

    public float health;
    public Image healthBar;


    public void TakeDamage(float damage){
       
        health -= damage;
        Debug.Log("Monster Damage taken");

    }


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        move = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = 0;
        isMoving=false;
        x_controller = -300;
        
    }

    void UpdateHealth(){
        healthBar.fillAmount = health/100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();

        if(health <= 0){
            Destroy(gameObject);
        }
        

        if(moveSpeed !=0){
            animator.SetBool("isMoving",true);
        }
        else
            animator.SetBool("isMoving",false);

        x_controller++;

        if(x_controller > 0){
            direction= 1;
            
            if(x_controller == 600)
                x_controller= -600;
              
        }
        else
            direction= -1;        
        
        if(direction < 0){
            transform.localScale = facingRight;
            healthBar.fillOrigin = 0;
        }
        
        if(direction > 0){
            transform.localScale = facingLeft;
            healthBar.fillOrigin = 1;
        }

        if(x_controller > 400 && x_controller <600){
            isMoving=false;
            moveSpeed=0;
        }
        else if(x_controller > -200 && x_controller < 0){
            isMoving=false;
            moveSpeed=0;
        }
        else{
            isMoving=true;
            moveSpeed=3;
        }

        

        if(isMoving==true && moveSpeed!=0)
            move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);
    }

    
}
