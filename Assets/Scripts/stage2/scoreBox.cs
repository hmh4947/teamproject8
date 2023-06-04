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
            gameController.GetScore(this.type);
            Destroy(other.gameObject);
        }       
    }
    
}
