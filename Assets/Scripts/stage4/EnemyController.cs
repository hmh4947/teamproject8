using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    Animator ani;
    Player player;
    Rigidbody2D rb;
    public float Distance;
    public GameObject Enemy;
    public Vector2 EnemyInitPos;
    private Transform enemyPos;
    public GameObject Laser;
    private bool isChase=false;

    

    void Start()
    {
        //선반 콜리전 무시
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("ledge"), true);
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        player = GetComponent<Player>();
        
        

    }
   
    void Update()
    {

        if (target.name == ("Laser") && isChase)
        {
            GameObject PlayerObj = GameObject.Find("Player");
            if(PlayerObj != null)
            {
                Transform LaserObj = PlayerObj.transform.Find("Laser(Clone)");
                if (LaserObj!=null)
                {
                    Test testCs = LaserObj.GetComponent<Test>();
                    if(testCs != null)
                    {
                        Debug.Log("target: Laser" + testCs.LaserT);
                        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, testCs.LaserT, Time.deltaTime * 7f);
                    }

                }
                else
                {
                   Debug.Log("없음" );
                }

            }
           
           
        }

        if (target.name == ("Player")&&isChase)
        {
            rb.isKinematic = true;
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, target.position, Time.deltaTime * 7f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Book")
        {
            Debug.Log("책과 충돌");
            Destroy(collision.gameObject);
            ani.SetBool("isChase", true);
            isChase = true;
        }
       
        
    }
}
