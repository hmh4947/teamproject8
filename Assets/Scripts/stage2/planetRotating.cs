using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRotating : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    RectTransform rectT;
    gameController gameController;
    void Start()
    {
        rectT = GetComponent<RectTransform>();
        gameController = FindObjectOfType<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,Time.deltaTime*3*(float)gameController.getCombo()));
    }
}
