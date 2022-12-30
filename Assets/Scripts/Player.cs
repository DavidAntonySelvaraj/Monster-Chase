using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float MoveSpeed = 10f;
    [SerializeField]private float JumpForce = 11f;
    //public float MaxVelocity = 22f;
    private float movementX;
    public Rigidbody2D myBody;
    private Animator anim;
    private string Walk_Animation = "Walk";
    private SpriteRenderer sr;
    public bool isGrounded;
    private string Ground_Tag = "Ground";
    private string Enemy_Tag = "Enemy";
   

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
       // Debug.Log("" + movementX);
        transform.position += new Vector3(movementX,0f,0f)  * MoveSpeed * Time.deltaTime;
    }
    void AnimatePlayer()
    {
        if (movementX ==1) 
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = false;
        }
        else if(movementX ==-1)
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(Walk_Animation, false);
        }
         
        
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //Debug.Log("Jump Pressed"); 
            isGrounded = false;
            myBody.AddForce(new Vector2 (0f,JumpForce),ForceMode2D.Impulse );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Ground_Tag))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


}//class










