using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button2 : MonoBehaviour
{
  //  public static bool state=false;
    public GameObject ButtonScreen2;
    public GameObject ButtonScreen3;
    public GameObject ButtonScreen4;
    public GameObject ButtonScreen5;
    public GameObject ButtonScreen6;
    public GameObject ButtonScreen6_1;
  //  public GameObject ButtonScreen61;
    public GameObject ButtonScreen7;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn2()
    {
        
            ButtonScreen2.SetActive(true);
            ButtonScreen3.SetActive(false);
            ButtonScreen4.SetActive(false);
            ButtonScreen5.SetActive(false);
            ButtonScreen6.SetActive(false);
            ButtonScreen6_1.SetActive(false);
        //   ButtonScreen61.SetActive(false);
            ButtonScreen7.SetActive(false);
        
      
        
    }
        public void btn3()
        {
        
            ButtonScreen2.SetActive(false);
            ButtonScreen3.SetActive(true);
            ButtonScreen4.SetActive(false);
            ButtonScreen5.SetActive(false);
            ButtonScreen6.SetActive(false);
            ButtonScreen6_1.SetActive(false);
     //    ButtonScreen61.SetActive(false);
            ButtonScreen7.SetActive(false);

        }
        public void btn4()
        {
      
            ButtonScreen2.SetActive(false);
            ButtonScreen3.SetActive(false);
            ButtonScreen4.SetActive(true);
            ButtonScreen5.SetActive(false);
            ButtonScreen6.SetActive(false);
            ButtonScreen7.SetActive(false);
            ButtonScreen6_1.SetActive(false);
      // ButtonScreen61.SetActive(false);
    }
        public void btn5()
        {
            ButtonScreen2.SetActive(false);
            ButtonScreen3.SetActive(false);
            ButtonScreen4.SetActive(false);
            ButtonScreen5.SetActive(true);
            ButtonScreen6.SetActive(false);
            ButtonScreen7.SetActive(false);
            ButtonScreen6_1.SetActive(false);
       //  ButtonScreen61.SetActive(false);

    }
    public void btn6()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(true);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(false);
      // ButtonScreen61.SetActive(false);

    }
    public void btn6_1()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(true);
      // ButtonScreen61.SetActive(true);

    }
    public void btn61()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(true);
        ButtonScreen7.SetActive(false);
      //  ButtonScreen6_1.SetActive(true);
      // ButtonScreen61.SetActive(true);

    }
    public void btn7()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(true);
       // ButtonScreen6_1.SetActive(false);
      // ButtonScreen61.SetActive(false);

    }
}
