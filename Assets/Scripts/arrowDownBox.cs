using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDownBox : MonoBehaviour
{
    SpriteRenderer sprite;
    gameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        gameController = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressed = Input.GetKey(KeyCode.DownArrow);
        
        if(gameController.isDownPressed()){
            sprite.color = Color.cyan;
        }else{
            sprite.color = Color.white;
        }
    }
}
