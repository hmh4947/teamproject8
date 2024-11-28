using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Option : MonoBehaviour
{
    public GameObject optionPrefab;
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
        GameManager.instance.gameObject.SetActive(true);
        SceneManagement.instance.gameObject.GetComponent<SceneManagement>().Option();
        isPause = true;
        Time.timeScale = 0;
        /* if (isPause == false)
         {
             Time.timeScale = 0;
             isPause = true;
             return;

         }*/
    }
  
}
