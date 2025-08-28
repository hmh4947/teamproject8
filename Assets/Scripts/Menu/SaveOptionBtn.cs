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

      
        Debug.Log("������Ʈ ������");

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    //���� ����
    public void GameSave()
    {
     
        //�ν��Ͻ� ����

        Instance = Instantiate(SavePrefeb, new Vector2(1200, 700), Quaternion.identity);

        //�ν��Ͻ� �θ� ����
        Instance.transform.parent=GameManager.Instance.transform;
        Instance.SetActive(false);
        //�ν��Ͻ��� ��ġ�� Button6_1Canvas���� ����

        //Instance.transform.parent = GameObject.Find("Button6_1Canvas").transform;
        if (GameManager.Instance != null)
        {
            Debug.Log("null �� �ƴ�");
            if (GameManager.Instance.transform.Find("MenuCanvas"))
            {

                if (GameManager.Instance.transform.Find("Canvas"))
                {
                    Debug.Log("ĵ������ ã��");
                }
            }
        }
        else
        {
            Debug.Log("�ν��Ͻ��� null");
        }


        Instance.SetActive(true);

        //���� ��(���������� �ӹ����� ��������) ������ ���� 
        PlayerPrefs.SetString("SaveScene", SceneManagement.instance.getCurrScene());
        PlayerPrefs.Save();

        //������ ����(�� �̸�, ���� ��¥)
     
        saveData.SavePoint = SceneManagement.instance.getCurrScene();

        
        Debug.Log(saveData.SavePoint + "�������� ����");

  

        Debug.Log( saveData.SavePoint + "����");

        //�����ϰ� â �ݱ�
        SaveOptionCanvas.SetActive(false);

        //�ִ� 3������ ���� ����
      // if (objectQueue.Count < 3)
        {
            //ť�� ����
            objectQueue.Enqueue(saveData);
 
            Debug.Log(objectQueue.Peek() + "Queue");
        }
    
    }
    //���� �ҷ�����
    public void GameLoad()
    {
        
        SceneManagement.instance.gameObject.GetComponent<SceneManagement>().BackSpace();

    }
}