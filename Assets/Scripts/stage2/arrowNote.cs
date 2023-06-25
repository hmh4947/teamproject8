using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowNote : MonoBehaviour
{
    BoxCollider2D Collider;
    gameController gameController;
    float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<gameController>();
        Collider = GetComponent<BoxCollider2D>();
        if(transform.rotation.eulerAngles.z == 90.0f
            || transform.rotation.eulerAngles.z == 270.0f){
            Collider.size = new Vector2(0.01f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.getFever()) speed = 3.0f;
        else speed =2.0f;
        if(gameController.isCleared()) return;
        transform.Translate(0,-Time.deltaTime*speed,0,Space.World);

        if(transform.position.y < -7.0f){
            gameController.miss();
            Destroy(gameObject);            
        }
    }

}
