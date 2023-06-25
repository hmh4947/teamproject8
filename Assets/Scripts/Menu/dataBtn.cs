using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dataBtn : MonoBehaviour
{
    public GameObject st2;
    public GameObject st3;
    public GameObject st4;
    public GameObject sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Clickbtn2()
    {
        st2.SetActive(true);
        sc.SetActive(true);
    }
    public void Clickbtn3()
    {
        st3.SetActive(true);
       sc.SetActive(true);
    }
    public void Clickbtn4()
    {
        st4.SetActive(true);
        sc.SetActive(true);
    }
    public void PlaySt2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void PlaySt3()
    {
      
    }
    public void PlaySt4()
    {
        SceneManager.LoadScene("Stage4");
    }
}
