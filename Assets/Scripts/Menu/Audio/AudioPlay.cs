using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;
   
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        musics = GameObject.FindGameObjectsWithTag("Music");
        if(musics.Length>=2)
        {
            Destroy(this.gameObject);

        }
      
        audioSource = GetComponent<AudioSource>();


       
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    // Update is called once per frame
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
