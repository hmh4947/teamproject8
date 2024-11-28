using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSpace : MonoBehaviour
{
    bool isPause;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    
    public void BackSpaceBtn()
    {
       
        //옵션창을 닫음
        SceneManagement.instance.gameObject.GetComponent<SceneManagement>().BackSpace();
        //퍼즈 풀기    
        isPause = false;
        Time.timeScale = 1;
        if (isPause == true)
        {
           Time.timeScale = 0;
           Debug.Log("Pause_false");
           isPause = false;
           return;

        }

        
    }
}
