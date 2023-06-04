using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMaker : MonoBehaviour
{

    public GameObject notePrefab;
    gameController gameController;
    // type 0 = left, 1 =  down, 2 =  right, 3 = up
    int type;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<gameController>();
        type = (int)(transform.rotation.eulerAngles.z/90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.getTimer() == 0 && gameController.getArrowType() == type){
            GameObject instance = (GameObject) Instantiate(notePrefab,transform.position,transform.rotation);
        }
    }
}
