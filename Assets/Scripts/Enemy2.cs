using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float stopDistance;

    private Transform target;

    public GameObject targetPosition;



    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


     
    }
    

    // Update is called once per frame
    private void Update()
    {
       

        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

 
    }

   
    void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Platform")
        {
        

            this.transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
          transform.position = Vector3.Slerp(gameObject.transform.position, targetPosition.transform.position, 0.1f);

            
        }
     }
    
   

}



