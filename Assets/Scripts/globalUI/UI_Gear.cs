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
