using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRotating : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    RectTransform rectT;
    void Start()
    {
        speed = 0.2f;
        rectT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,speed));
    }
}
