using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuFalse : MonoBehaviour
{
    private Button btn1,btn2,btn3,btn4,btn5,btn6,btn7;
   

    // Start is called before the first frame update
    void Start()
    {
        btn1 = GameObject.Find("Button1").GetComponent<Button>();
        btn2 = GameObject.Find("Button2").GetComponent<Button>();
        btn3 = GameObject.Find("Button3").GetComponent<Button>();
        btn4 = GameObject.Find("Button4").GetComponent<Button>();
        btn5 = GameObject.Find("Button5").GetComponent<Button>();
        btn6 = GameObject.Find("Button6").GetComponent<Button>();
        btn7 = GameObject.Find("Button7").GetComponent<Button>();

    }
   
    // Update is called once per frame
    void Update()
    {

    }

    public void btnNo()
    {

        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        btn5.interactable = false;
        btn6.interactable = false;
        btn7.interactable = false;


    }
}