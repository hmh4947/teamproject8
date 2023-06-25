using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    bool isPause;
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        isPause = true;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene(sceneIndex - 1);
            if (isPause == true)
            {
                Time.timeScale = 1;
                isPause = false;
                return;

            }
        }
    }
}
