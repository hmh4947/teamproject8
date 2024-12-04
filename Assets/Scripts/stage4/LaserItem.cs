using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserItem : MonoBehaviour,IItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
    public void TakeItem()
    {
        Destroy(this.gameObject);
        Debug.Log("È¹µæ");
 
    }
 
}
