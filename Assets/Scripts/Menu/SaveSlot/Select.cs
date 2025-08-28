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
    private int dataCount=0;

    //�� �̸� ���� 
    private string Nowname;
    //��¥ �� �ð� 
    private string Nowdate;
    //count
    private int Nowcount;

    public DateTime[] array = new DateTime[3];
    public DateTime dateTime1;
    public DateTime dateTime2;
    public DateTime dateTime3;

    void Start()
    {

        //����� �����Ͱ� �ִ��� Ȯ��
        for (int i = 0; i < 3; i++)
        {
            //�����Ͱ� �ִ°��
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
              
                //true�� ��ȯ
                savefile[i] = true;
                //������ ���� ��ȣ ����
                DataManager.instance.nowSlot = i;
                //�ش� ���� ������ �ҷ���
                DataManager.instance.LoadData();
                //��ư�� ��¥ �� �ð� ǥ��
                slotText[i].text = DataManager.instance.nowPlayer.date;

            }
            else
            {
                slotText[i].text = "�������";
            }
        }


    }
 
 
    public void PlayGame(string name)
    {
        
        //�ɼ�â�� ����
        int i;
        i = num;
       
        //���� ���� ��ȣ�� true��� 
        if (File.Exists(DataManager.instance.path + $"{i}"))
        {
            if (savefile[i])
            {//��ư Ŭ���ϸ� ���� ���� �ε����� �޾�
                
                // �� �ε����� ������ ����
                name = DataManager.instance.nowPlayer.sceneIndex;
                //������ �ε�
                DataManager.instance.LoadData();
                //�� �ε�
                SceneManager.LoadScene(name);
                Debug.Log("���� ������ ���� Scene Name: " + name);

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

        //count
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
    //����� Slot ��ġ�� ����
    public void CountSlot()
    {
        Debug.Log("ī��Ʈ: " + count);
        for (int i = 0; i < 3; i++)
        {
            
            Debug.Log("����" + i);
            DataManager.instance.nowSlot = i;
            //�ش� ���� ������ �ҷ���
            //�����Ͱ� �ִٸ�
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {

                Debug.Log("�����Ͱ� �ִ� ���� ���Կ�");
                dataCount++;

            }
            //�����Ͱ� ���ٸ� ����
            if (!File.Exists(DataManager.instance.path + $"{i}"))
            { //���� �����͸� �޾ƿ���
                NowData();
                //������ ����
                SetData(Nowname, Nowdate, Nowcount);
                break;
            }
        }
        Debug.Log("dataCount: " + dataCount);
        //������ �� ī��Ʈ�� 3�̻��̶�� ����ִ� �迭�� ���⿡ �����
        if (dataCount >= 3)
        {
            Debug.Log("������������" );

            NowData();
            SetData(Nowname, Nowdate, Nowcount);
       
            DataManager.instance.SaveData();

        }
        dataCount=0;
        count++;
      
        //count�� �÷���
        DataManager.instance.nowPlayer.count++;
    }
    //�ֱ� ���Ϻ��� ����
    public void SortSlot()
    {
       
        //�����Ͱ� �ִ°��
        if (File.Exists(DataManager.instance.path + $"{0}"))
        {
            //�ð� �����͸� ������
            DataManager.instance.LoadDataSlot(0);
            //�ش� ���� ������ �ҷ���

            dateTime1 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
            "yyyy/MM/dd/HH:mm:ss", null);
            array[0] = dateTime1;

            Debug.Log("dateData0 ������ �ð�: " + dateTime1);
   
        }
        if (File.Exists(DataManager.instance.path + $"{1}"))
        {       //�ð� �����͸� ������
            DataManager.instance.LoadDataSlot(1);
            dateTime2 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
            "yyyy/MM/dd/HH:mm:ss", null);
            array[1] = dateTime2;

            Debug.Log("dateData0 ������ �ð�: " + dateTime2);
        
        }
        if (File.Exists(DataManager.instance.path + $"{2}"))
        {
            DataManager.instance.LoadDataSlot(2);
            dateTime3 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
               "yyyy/MM/dd/HH:mm:ss", null);
            array[2] = dateTime3;

            Debug.Log("dateData0 ������ �ð�: " + dateTime3);

        }
        else
        {
            Debug.Log("������ ����");
        }

        //����
   
        Array.Sort(array);
        Debug.Log("���ĵ� ����: " + string.Join(", ", array));

       //���ĵ� ������� ���Կ� �ֱ�
    }
 
    public void Print()
    {  
        CountSlot();
      
        DataManager.instance.LoadData();
       // SortSlot();
        saveOption.SetActive(false);


    }
}
