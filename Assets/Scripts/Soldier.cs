using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    public Rigidbody2D move;
    public int moveSpeed;
    public float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public Animator animator;

    public float health;
    public Image healthBar;

    private int deathTime;
    private int endScreenTime;

    private bool isWalking;

    private int counter;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource potionSoundEffect;
    [SerializeField] private AudioSource playerHurtSoundEffect;
    [SerializeField] private AudioSource horseFoundSoundEffect;


    [SerializeField] Transform groundCheckCollider;
    const float groundCheckRadius = 0.2f;
    bool isGrounded = false;
    [SerializeField] LayerMask groundLayer;

    void UpdateHealth(){
        healthBar.fillAmount = health/100;
    }


    public void LifePotion(){

        health=100;
        Debug.Log("Life potion taken");
        potionSoundEffect.Play();

    }


    public void TakeDamage(int damage){
       
        health -= damage;
        Debug.Log("Soldier Life: "+ health);
        playerHurtSoundEffect.Play();

    }

    public void HorseFound(){
        Debug.Log("Horse Found");
        horseFoundSoundEffect.Play();
        if(endScreenTime==0)
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen");
        else
            endScreenTime--;

    }

    public void NextPhase(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene2");
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


        health = 100;
        deathTime=200;
        endScreenTime= 200;
        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        
        if(health <= 0){
            animator.SetBool("isDying",true);
            if(deathTime==100)
                deathSoundEffect.Play();
                
            if(deathTime==0){
                Destroy(this.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScreen");
            }
            deathTime--;
        }

        if(transform.position.y < -7)
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScreen");
        

        if(Input.GetAxis("Horizontal")!=0 && health>0){
            animator.SetBool("isWalking",true);
        }
        else
            animator.SetBool("isWalking",false);
        

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ) && isGrounded && health>0){
            jumpSoundEffect.Play();
            move.velocity = Vector2.up * 10;
        }

        direction = Input.GetAxis("Horizontal");

        if(health>0)  
            move.velocity = new Vector2(direction * moveSpeed, move.velocity.y);
        else
            moveSpeed=0;

        if(direction > 0){
            transform.localScale = facingRight;
            healthBar.fillOrigin = 0;
        }
        if(direction < 0){
            transform.localScale = facingLeft;
            healthBar.fillOrigin = 1;
        }

    }

    void FixedUpdate(){
        GroundCheck();
    }

    void GroundCheck(){
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if(colliders.Length>0){
            isGrounded = true;
        }
    }
}
