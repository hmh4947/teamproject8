using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public float runSpeed;
    public float currentSpeed;
    private bool walking = true;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
   // bool isJumping = false;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

       
    }

    void Update()
    {
        FixedUpdate();
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            
        //Directoin sprite
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
             
        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.1)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > currentSpeed)//Right Max Speed
            rigid.velocity = new Vector2(currentSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < currentSpeed * (-1))//Left Max Speed
            rigid.velocity = new Vector2(currentSpeed * (-1), rigid.velocity.y);


    }

    void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.RightControl) ||
               Input.GetKeyDown(KeyCode.LeftControl)))
        {
           if (walking)
            {
               
                currentSpeed = runSpeed;
                anim.SetBool("isRunning", true);
                walking = false;
           }
           
            else
            {
               
                currentSpeed = maxSpeed;
                anim.SetBool("isRunning", false);
                walking = true;
            }
           
        }

        Move();

        
        
        if (rigid.velocity.y < 0 && anim.GetBool("isJumping"))
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 0.5f, LayerMask.GetMask("PlatForm"));
 
         if (rayhit.collider != null)
            {
          //if (rayhit.distance < 0.5f)
             anim.SetBool("isJumping", false);
                
            }

             anim.SetBool("isJumping", false);
        }

       

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            SceneManager.LoadScene("Stage4");

        
    }
}
