using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public bool isChase=false;
    public float moveSpeed=1.0f;
    

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
       
        if (isChase)
        {


            if (target.CompareTag("Laser"))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
            }
            else if (target.CompareTag("Player"))
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
            }

        }

        if (target.name == ("Player")&&isChase)
        {
            rb.isKinematic = true;
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, target.position, Time.deltaTime * moveSpeed);
        }

    }
    public void SetLaserTarget(Transform laser)
    {
        target = laser;
        Debug.Log($"[EnemyChase] 타겟 변경됨 → {laser.name}, tag: {laser.tag}");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Book")
        {
         
            Destroy(collision.gameObject);
            ani.SetBool("isChase", true);
            isChase = true;
            if (target == null)
            {
                GameObject playerObj = GameObject.FindWithTag("Player");
                if (playerObj != null)
                    target = playerObj.transform;
            }


        }
       
        
    }
}
