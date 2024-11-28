using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public List<string> scenes = new List<string>();
    public string Curr_Scene;
    public string Prev_Scene;
    private string temp;
    public static SceneManagement instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static SceneManagement Instance
    {
        get
        {
            if (instance == null)
            {
                return null;

            }
            return instance;
        }
    }

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        Curr_Scene = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        if (Curr_Scene != SceneManager.GetActiveScene().name)
        {
            Prev_Scene = Curr_Scene;
            Curr_Scene = SceneManager.GetActiveScene().name;
         
        }
      

    }
  
    public void Option()
    {
          temp=Curr_Scene;
          Prev_Scene = Curr_Scene;
          Curr_Scene = SceneManager.GetActiveScene().name;



        Debug.Log("¿É¼Ç");

        
    }
    public void BackSpace()
    {
        GameManager.instance.gameObject.SetActive(false);
    }
}
