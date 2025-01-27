using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public List<string> scenes = new List<string>();
    public string Curr_Scene;
    private string Prev_Scene;
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
    //Curr_Scene == scenes[0]으로 
    void Start()
    {
       

        Debug.Log(SceneManager.GetActiveScene().name);
        Curr_Scene = SceneManager.GetActiveScene().name;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        scenes[0] = Prev_Scene;
        scenes[1] = Curr_Scene;
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



        Debug.Log("옵션");

        
    }
    public void BackSpace()
    {
        GameManager.getInstance().gameObject.SetActive(false);
    }
    public string getCurrScene()
    {
       
        return scenes[0];
      
    }
    public void setCurrScene (string curr_scene)
    {
        
     
        Curr_Scene =curr_scene;
    }

   
    
}
