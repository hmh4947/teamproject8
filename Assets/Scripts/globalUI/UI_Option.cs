using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Option : MonoBehaviour
{
    bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void option()
    {
        SceneManager.LoadScene("Menu");
        if (isPause == false)
        {
            Time.timeScale = 0;
            isPause = true;
            return;

        }
        
    }
    
}
