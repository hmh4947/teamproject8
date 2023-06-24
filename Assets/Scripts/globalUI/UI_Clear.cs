using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Clear : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectT;
    bool view;
    void Start()
    {
        view = false;
        rectT = GetComponent<RectTransform>();
        rectT.position = new Vector2(0,0); 
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setPosCenter(){
        view = !view;
        gameObject.SetActive(view);
    }
}
