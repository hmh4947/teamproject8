using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   public Vector2 LaserT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserT = transform.position;
     //   Debug.Log("���� ��ġ: " + transform.localPosition);
        Debug.Log("���� ��ġ: " + LaserT);
    }
}
