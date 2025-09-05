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

    private DateTime dateText1;
    private DateTime dateText2;
    private DateTime dateText3;

   // public DateTime[] array = new DateTime[3];


            
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
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("���� ��� ����: " + path);
        }
    }

    private void Start()
    {
        
       
    }
    public int FindSaveSlot(string sceneName, string date, int count)
    {
        nowPlayer.sceneIndex = sceneName;
        nowPlayer.date = date;
        nowPlayer.count = count;

        // �� ���� ã��
        for (int i = 0; i < 3; i++)
        {
            string p = Path.Combine(path, $"save{i}.json");
            if (!File.Exists(p))
            {
                nowSlot = i;
                SaveData();
                //�� ���� ã���� ���Թ�ȣ ��ȯ
                return i;
            }
        }

        // �� á���� ������ ����
        nowSlot = GetOldestSlotIndex();
        SaveData();
        return nowSlot;
    }
    
    //������ �ð��� ���� ã��
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
   
        return oldestIndex;
    }

    public void SaveData()
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        if (string.IsNullOrEmpty(nowPlayer.date))
            nowPlayer.date = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

        string filePath = Path.Combine(path, $"save{nowSlot}.json"); 
        string data = JsonUtility.ToJson(nowPlayer, true);
        File.WriteAllText(filePath, data);

    }
   

    public void LoadDataSlot(int i)
    {
        string filePath = Path.Combine(path, $"save{i}.json");
        string data = File.ReadAllText(filePath);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

    }
  


}
