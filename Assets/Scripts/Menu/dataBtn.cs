using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dataBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clickbtn1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Clickbtn2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Clickbtn3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Clickbtn4()
    {
        SceneManager.LoadScene("Stage4");
    }
}
