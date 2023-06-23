using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, -0.4f, -7.3f);
    }
}
