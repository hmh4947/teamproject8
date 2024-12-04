using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public float runSpeed;
    public float currentSpeed;
    private bool walking = true;
    public Transform PlayerT;
    public GameObject LaserObj;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float LaserDistance = 2.0f;
    private GameManager InstantiateObj;
    public GameObject PlayerObj;
    public Transform EnemyT;
   


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
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            if (Input.GetAxisRaw("Horizontal") == -1 && PlayerObj != null) 
            {
                PlayerObj.transform.position = new Vector3(PlayerT.position.x - LaserDistance, PlayerT.position.y);

                Debug.Log("왼쪽");
            }
            if (Input.GetAxisRaw("Horizontal") == 1 && PlayerObj != null)
            {
                PlayerObj.transform.position = new Vector3(PlayerT.position.x + LaserDistance, PlayerT.position.y);
            
                Debug.Log("오른쪽");
            }
           
        }

     
          


        if (Mathf.Abs(rigid.velocity.x) < 0.1)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

       

    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Right Max Speed
        if (rigid.velocity.x > currentSpeed)
            rigid.velocity = new Vector2(currentSpeed, rigid.velocity.y);

        //Left Max Speed
        else if (rigid.velocity.x < currentSpeed * (-1))
            rigid.velocity = new Vector2(currentSpeed * (-1), rigid.velocity.y);


    }

    void FixedUpdate()
    {
        Move();

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

        //Landing Platform

       
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector2.down, 0.5f, LayerMask.GetMask("PlatForm"));
            if (anim.GetBool("isJumping"))
            { 
               
                if (rayhit.collider != null)
                {
                    if (rayhit.distance < 0.5f)
                    {
                        anim.SetBool("isJumping", false);
                        Debug.Log(rayhit.collider.name);
                    }
                }
               
            }
            anim.SetBool("isJumping", false);
        }

       
    }


    
    void OnCollisionEnter2D(Collision2D collision)
    {
        IHealth health = gameObject.GetComponent<IHealth>();
        if (collision.gameObject.tag == "Enemy")
        {
          //  SceneManager.LoadScene("Stage4");
            // Debug.Log("재시작");
            
            if (health != null)
            {
                //stage4 재시작
                health.Death();
                Debug.Log("재시작");
            }
           

        }


        IItem item = collision.gameObject.GetComponent<IItem>();
        if (item != null)
        {
           item.TakeItem();
           EnemyT.GetComponent<EnemyController>().target=LaserObj.transform;
           DrawLaser();
           Debug.Log("충돌");
        }
        
    }

    void DrawLaser()
    {
     
        
        if(spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1)
        {
            PlayerObj=Instantiate(LaserObj, new Vector2(PlayerT.position.x + LaserDistance, PlayerT.position.y), Quaternion.identity);
            //부모를 Player로 설정
            PlayerObj.transform.parent=gameObject.transform;
            Debug.Log("오른쪽");
        }
        else
        {
            PlayerObj = Instantiate(LaserObj, new Vector2(PlayerT.position.x - LaserDistance, PlayerT.position.y), Quaternion.identity);
            PlayerObj.transform.parent = gameObject.transform;
            Debug.Log("왼쪽");
        }
    }
   
    
}
