using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public struct SaveData
{
    public string SavePoint;
    public string DateText;
}

public class SaveOptionBtn : MonoBehaviour
{
    public GameObject SaveOptionCanvas;
   // public Text dateText;

    public SaveData saveData;

    public Queue<SaveData> objectQueue;
    public GameObject SavePrefeb;
    private GameObject Instance;
  
    void Start()
    {

     
        objectQueue = new Queue<SaveData>();

      
        Debug.Log("컴포넌트 가져옴");

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    //게임 저장
    public void GameSave()
    {
     
        //인스턴스 생성

        Instance = Instantiate(SavePrefeb, new Vector2(1200, 700), Quaternion.identity);

        //인스턴스 부모 설정
        Instance.transform.parent=GameManager.Instance.transform;
        Instance.SetActive(false);
        //인스턴스의 위치를 Button6_1Canvas에서 생성

        //Instance.transform.parent = GameObject.Find("Button6_1Canvas").transform;
        if (GameManager.Instance != null)
        {
            Debug.Log("null 이 아님");
            if (GameManager.Instance.transform.Find("MenuCanvas"))
            {

                if (GameManager.Instance.transform.Find("Canvas"))
                {
                    Debug.Log("캔버스를 찾음");
                }
            }
        }
        else
        {
            Debug.Log("인스턴스가 null");
        }


        Instance.SetActive(true);

        //이전 씬(마지막으로 머물렀던 스테이지) 데이터 저장 
        PlayerPrefs.SetString("SaveScene", SceneManagement.instance.getCurrScene());
        PlayerPrefs.Save();

        //데이터 저장(씬 이름, 저장 날짜)
     
        saveData.SavePoint = SceneManagement.instance.getCurrScene();

        
        Debug.Log(saveData.SavePoint + "가져오기 성공");

  

        Debug.Log( saveData.SavePoint + "저장");

        //저장하고 창 닫기
        SaveOptionCanvas.SetActive(false);

        //최대 3개까지 저장 가능
      // if (objectQueue.Count < 3)
        {
            //큐에 저장
            objectQueue.Enqueue(saveData);
 
            Debug.Log(objectQueue.Peek() + "Queue");
        }
    
    }
    //게임 불러오기
    public void GameLoad()
    {
        
        SceneManagement.instance.gameObject.GetComponent<SceneManagement>().BackSpace();

    }
}