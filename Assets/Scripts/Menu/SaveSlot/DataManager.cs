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
    //카운트 세기
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
    public int GetOldestSlotIndex()
    {
        DateTime oldest = DateTime.MaxValue;
        int oldestIndex = 0;

        for (int i = 0; i < 3; i++)
        {
            string filePath = Path.Combine(path, $"save{i}.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                PlayerData temp = JsonUtility.FromJson<PlayerData>(json);
                DateTime date = DateTime.ParseExact(temp.date, "yyyy/MM/dd/HH:mm:ss", null);

                if (date < oldest)
                {
                    oldest = date;
                    oldestIndex = i;
                }
            }
        }
        Debug.Log("oldestIndex: " + oldestIndex);
        return oldestIndex;
    }

    public void SaveData()
    {
        int oldSlot=GetOldestSlotIndex();

        string data = JsonUtility.ToJson(nowPlayer);
        if (CountQ < 3)
        {
            
            File.WriteAllText(path + nowSlot.ToString(), data);
            Debug.Log("저장");
            //큐에 객체를 넣음
            DataQueue.Enqueue(data);
            CountQ++;
        }
        else
        {

            //오래된 저장본 삭제

            int deleteCount = oldSlot;
            DataQueue.Dequeue();
            File.Delete(path + deleteCount.ToString());
      
            //새로운 저장본 삽입
            //삭제된 save+카운트 이름으로 파일생성
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
