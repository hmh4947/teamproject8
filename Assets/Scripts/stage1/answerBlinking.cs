using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerBlinking : MonoBehaviour
{
    float time;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        start = false;       
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 0.5f){
             GetComponent<CanvasRenderer>().SetAlpha(1 - time);
        }else{
             GetComponent<CanvasRenderer>().SetAlpha(time);
             if(time > 1f){
                 time =0;
                 start = false;
             }
        }
        if(start) time += Time.deltaTime*1.2f;
    }

    public void startBlinking(int type) {
        switch(type){
            case 0:
                GetComponent<CanvasRenderer>().SetColor(Color.red);
            break;
            case 1:
                GetComponent<CanvasRenderer>().SetColor(Color.green);
            break;
            case 2:
                GetComponent<CanvasRenderer>().SetColor(Color.blue);
            break;
            case 3:
                GetComponent<CanvasRenderer>().SetColor(Color.yellow);
            break;
        }
        start = true;
    }
}
