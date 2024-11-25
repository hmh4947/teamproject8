using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    //  public static bool state=false;
    public GameObject Menu;
    public GameObject ButtonScreen2;
    public GameObject ButtonScreen3;
    public GameObject ButtonScreen4;
    public GameObject ButtonScreen5;
    public GameObject ButtonScreen6;
    public GameObject ButtonScreen6_1;
    public GameObject ButtonScreen7;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReGameBtn()
    {
        SceneManager.LoadScene("Stage1");
        Menu.SetActive(false);
        
    }
    public void SoundBtn()
    {

        ButtonScreen2.SetActive(true);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen6_1.SetActive(false);

        ButtonScreen7.SetActive(false);



    }
    public void KeyboardBtn()
    {

        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(true);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen6_1.SetActive(false);
        ButtonScreen7.SetActive(false);

    }
    public void ScreenBtn()
    {

        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(true);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(false);
    }

    public void SaveBtn()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(true);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(false);

    }
    public void LoadBtn()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(true);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(false);
        Debug.Log("실행");
    }
    public void btn6_1Btn()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(false);
        ButtonScreen6_1.SetActive(true);
        Debug.Log("실행");
    }
    public void btn61Btn()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(true);
        ButtonScreen7.SetActive(false);

    }
    public void ExitBtn()
    {
        ButtonScreen2.SetActive(false);
        ButtonScreen3.SetActive(false);
        ButtonScreen4.SetActive(false);
        ButtonScreen5.SetActive(false);
        ButtonScreen6.SetActive(false);
        ButtonScreen7.SetActive(true);

    }
}
