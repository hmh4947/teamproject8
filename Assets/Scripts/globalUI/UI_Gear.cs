using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gear : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite gear0, gear1, gear2, gear3;
    void Start()
    {
        //GetComponent<Image>().sprite.bounds.size.Set(gear0.bounds.size.x,gear0.bounds.size.y,gear0.bounds.size.z);
        GetComponent<RectTransform>().sizeDelta = new Vector2(gear0.bounds.size.x*22,gear0.bounds.size.y*22);
        GetComponent<RectTransform>().position.Set(350,260,0);
        Debug.Log(gear0.bounds.size);
        gameUIcontroller.currentGear = 0;
        switch(gameUIcontroller.currentGear){
            case 0:
            GetComponent<Image>().sprite = gear0;
            break;
            case 1:
            GetComponent<Image>().sprite = gear1;
            break;
            case 2:
            GetComponent<Image>().sprite = gear2;
            break;
            case 3:
            GetComponent<Image>().sprite = gear3;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
