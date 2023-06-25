using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBox : MonoBehaviour
{
    // Start is called before the first frame update
    gameController gameController;     
    SpriteRenderer sprite;
    // 0: perfect 1: good 2: bad 3: miss
    public int type;

    void Start()
    {
        gameController = FindObjectOfType<gameController>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other) {        
        if(gameController.isAnykeyPressed() && other.CompareTag("note")){
            if(!checkRightPosition(other)) return;
            gameController.GetScore(this.type);
            Destroy(other.gameObject);
        }       
    }

    bool checkRightPosition(Collider2D other){
        float angle = other.transform.rotation.eulerAngles.z;
        float posX = other.transform.position.x;
        Debug.Log(angle + ", " + posX);
        if(angle == 0.0f && posX == -1.5f && gameController.isLeftPressed()){ // left
            return true;
        }else if(angle == 270.0f && posX == -0.5f && gameController.isUpPressed()){ // up
            return true;
        }else if(angle == 180.0f && posX == 0.5f && gameController.isRightPressed()){ // right
            return true;
        }else if(angle == 90.0f && posX == 1.5f && gameController.isDownPressed()){ // down
            return true;
        }
        return false;
    }
    
}
