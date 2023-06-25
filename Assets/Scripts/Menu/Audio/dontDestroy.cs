using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private GameObject[] sound;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        sound = GameObject.FindGameObjectsWithTag("Slider");
        if (sound.Length >= 2)
        {
            Destroy(this.gameObject);

        }

 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
