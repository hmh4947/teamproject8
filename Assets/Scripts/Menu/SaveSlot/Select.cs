using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Select : MonoBehaviour
{
    public Text[] slotText;
    bool[] savefile = new bool[3]; //���̺� ���� ���� ����
    private int count;
    public int num=0;
    public string Scenename;
    public GameObject saveOption;


    //�� �̸� ���� 
    private string Nowname;
    //��¥ �� �ð� 
    private string Nowdate;
   
    private int Nowcount;

    public DateTime[] array = new DateTime[3];
    public DateTime dateTime1;
    public DateTime dateTime2;
    public DateTime dateTime3;

    void Start()
    {
        // ���� ������ �������� ������ ����
        if (!Directory.Exists(DataManager.instance.path))
            Directory.CreateDirectory(DataManager.instance.path);

        // ���� 3�� ��ȸ
        for (int i = 0; i < 3; i++)
        {
            string filePath = Path.Combine(DataManager.instance.path, $"save{i}.json");

            if (File.Exists(filePath))
            {
                // ������ �ε�
                DataManager.instance.LoadDataSlot(i);

                // UI�� ��¥ ǥ��
                slotText[i].text = DataManager.instance.nowPlayer.date;

                // �ش� ���� ��� ���� ǥ��
                savefile[i] = true;
            }
            else
            {
                slotText[i].text = "�������";
                savefile[i] = false;
            }
        }

    }
 
 
    public void PlayGame()
    {
        // ������ ���� ��ȣ
        int slotIndex = num; 
        string filePath = Path.Combine(DataManager.instance.path, $"save{slotIndex}.json");

        if (File.Exists(filePath))
        {
 
            DataManager.instance.LoadDataSlot(slotIndex);

            string sceneToLoad = DataManager.instance.nowPlayer.sceneIndex;

            if (!string.IsNullOrEmpty(sceneToLoad))
            {
            
                SceneManager.LoadScene(sceneToLoad);
            }
        
        }
        

    }


   
    //���� �����͸� �޾ƿ���
    public void NowData()
    {
        //�� �̸� ���� 
        Nowname = SceneManagement.Instance.scenes[0].ToString();
      
        //��¥ �� �ð� 
        Nowdate = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

        Nowcount = count;

        Debug.Log("���� ������" + Nowname);
        Debug.Log("���� ������" + Nowdate);
        Debug.Log("���� ������" + Nowcount);
    }
    public void SetData(string name, string data, int count)
    {
        //�޾ƿ� ���� nowPlayer ������ ���� �־� ����
        DataManager.instance.nowPlayer.sceneIndex = name;
        DataManager.instance.nowPlayer.date = data;
        DataManager.instance.nowPlayer.count = count;
        //�����͸� �ν��Ͻ��� ����
        DataManager.instance.SaveData();
    }

    public void CountSlot()
    {
        NowData();
        DataManager.instance.FindSaveSlot(Nowname, Nowdate, Nowcount);
        SetUI();                  
        saveOption.SetActive(false);
    }
    //�ֱ� ���Ϻ��� ����

    private void SetUI()
    {
        for (int i = 0; i < 3; i++)
        {
            string p = Path.Combine(DataManager.instance.path, $"save{i}.json");
            if (File.Exists(p))
            {
                DataManager.instance.LoadDataSlot(i);
                slotText[i].text = DataManager.instance.nowPlayer.date;
            }
            else slotText[i].text = "�������";
        }
    }
    public void Print()
    {  
        CountSlot();
        saveOption.SetActive(false);

    }
}
