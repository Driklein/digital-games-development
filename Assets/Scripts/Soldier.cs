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
    public Animator animator;
    public int health;
    private int deathTime;
    private int endScreenTime;

    private bool isJumping;
    private bool isWalking;

    private int counter;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    //[SerializeField] private AudioSource hurtSoundEffect;
    //[SerializeField] private AudioSource stepsSoundEffect;
    //[SerializeField] private AudioSource horseFoundSoundEffect;
    [SerializeField] private AudioSource potionSoundEffect;

    public void LifePotion(){

        health=100;
        Debug.Log("Life potion taken");
        potionSoundEffect.Play();

    }


    public void TakeDamage(int damage){
       
        health -= damage;
        Debug.Log("Soldier Life: "+ health);


    }

    public void HorseFound(){
        Debug.Log("Horse Found");
        //horseFoundSoundEffect.Play();
        if(endScreenTime==0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        else
            endScreenTime--;

    }

    // Start is called before the first frame update
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        move = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = 5;

        isJumping=false;

        health = 100;
        deathTime=200;
        endScreenTime= 300;
        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            animator.SetBool("isDying",true);
            if(deathTime==100)
                deathSoundEffect.Play();
                
            if(deathTime==0)
                //Destroy(gameObject);
            deathTime--;
        }

        if(Input.GetAxis("Horizontal")!=0 && health>0){
            animator.SetBool("isWalking",true);
        }
        else
            animator.SetBool("isWalking",false);
        

        if(Input.GetKeyDown(KeyCode.UpArrow) && !isJumping && health>0){
            jumpSoundEffect.Play();
            move.velocity = Vector2.up * 10;
            isJumping=true;
        }

        direction = Input.GetAxis("Horizontal");

        if(health>0)  
            move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);

        if(health==0)
            moveSpeed=0;

        if(direction > 0){
            transform.localScale = facingRight;
        }
        if(direction < 0){
            transform.localScale = facingLeft;
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isJumping=false;
        }
    }
}
