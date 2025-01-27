using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System;

public class PlayerData
{
    public string sceneIndex;
    public string date;
    //ī��Ʈ ����
    public int count;
}
public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager instance;
    public PlayerData nowPlayer=new PlayerData();
    public string path;
    public int nowSlot;
    public int deleteSlot;

    public Queue<string> DataQueue;
    public int CountQ=0;

    private DateTime dateText1;
    private DateTime dateText2;
    private DateTime dateText3;
    public GameObject obj;
    public DateTime[] array = new DateTime[3];


            
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
         
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        path = Application.persistentDataPath+"/save";
     
    }

    private void Start()
    {
        DataQueue=new Queue<string>();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        if (CountQ < 3)
        {
            
            File.WriteAllText(path + nowSlot.ToString(), data);
            Debug.Log("����");
            //ť�� ��ü�� ����
            DataQueue.Enqueue(data);
            CountQ++;
        }
        else
        {
            // obj.GetComponent<Select>().NowData();

            //������ ���庻 ����

            int deleteCount = nowPlayer.count % 3;
;           DataQueue.Dequeue();
            File.Delete(path + deleteCount.ToString());
            Debug.Log("nowPlayer.count: " + nowPlayer.count);
            Debug.Log("deleteCount: " + deleteCount);
            //���ο� ���庻 ����
            //������ save+ī��Ʈ �̸����� ���ϻ���
            File.WriteAllText(path + deleteCount.ToString(), data);
             Debug.Log("data: " + data);
           
            DataQueue.Enqueue(data);
        


        }

    }
   
    public void LoadData()
    {
        string data=File.ReadAllText(path+ nowSlot.ToString());
        nowPlayer=JsonUtility.FromJson<PlayerData>(data);
       
    }
    public void LoadDataSlot(int i)
    {
        string data = File.ReadAllText(path + i.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

    }
    // Update is called once per frame
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }

}
