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
       
        //�ɼ�â�� ����
        SceneManagement.instance.gameObject.GetComponent<SceneManagement>().BackSpace();
        //���� Ǯ��    
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
