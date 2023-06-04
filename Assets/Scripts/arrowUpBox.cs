using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowUpBox : MonoBehaviour
{
    SpriteRenderer sprite;
    gameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameController =  FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(gameController.isUpPressed()){
            sprite.color = Color.blue;
        }else{
            sprite.color = Color.white;
        }
    }
}
