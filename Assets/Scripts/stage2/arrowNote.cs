using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowNote : MonoBehaviour
{
    BoxCollider2D Collider;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        if(transform.rotation.eulerAngles.z == 90.0f
            || transform.rotation.eulerAngles.z == 270.0f){
            Collider.size = new Vector2(0.01f, 1.0f);
            Debug.Log("change");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0,-Time.deltaTime*2,0,Space.World);

        if(transform.position.y < -10.0f){
            Destroy(gameObject);            
        }
    }
}
