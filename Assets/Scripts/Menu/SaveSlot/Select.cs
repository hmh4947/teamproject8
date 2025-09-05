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
    bool[] savefile = new bool[3]; //세이브 파일 존재 유무
    private int count;
    public int num=0;
    public string Scenename;
    public GameObject saveOption;


    //씬 이름 정보 
    private string Nowname;
    //날짜 및 시간 
    private string Nowdate;
   
    private int Nowcount;

    public DateTime[] array = new DateTime[3];
    public DateTime dateTime1;
    public DateTime dateTime2;
    public DateTime dateTime3;

    void Start()
    {
        // 저장 폴더가 존재하지 않으면 생성
        if (!Directory.Exists(DataManager.instance.path))
            Directory.CreateDirectory(DataManager.instance.path);

        // 슬롯 3개 순회
        for (int i = 0; i < 3; i++)
        {
            string filePath = Path.Combine(DataManager.instance.path, $"save{i}.json");

            if (File.Exists(filePath))
            {
                // 데이터 로드
                DataManager.instance.LoadDataSlot(i);

                // UI에 날짜 표시
                slotText[i].text = DataManager.instance.nowPlayer.date;

                // 해당 슬롯 사용 가능 표시
                savefile[i] = true;
            }
            else
            {
                slotText[i].text = "비어있음";
                savefile[i] = false;
            }
        }

    }
 
 
    public void PlayGame()
    {
        // 선택한 슬롯 번호
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


   
    //현재 데이터를 받아오기
    public void NowData()
    {
        //씬 이름 정보 
        Nowname = SceneManagement.Instance.scenes[0].ToString();
      
        //날짜 및 시간 
        Nowdate = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

        Nowcount = count;

        Debug.Log("현재 데이터" + Nowname);
        Debug.Log("현재 데이터" + Nowdate);
        Debug.Log("현재 데이터" + Nowcount);
    }
    public void SetData(string name, string data, int count)
    {
        //받아온 값을 nowPlayer 데이터 값에 넣어 설정
        DataManager.instance.nowPlayer.sceneIndex = name;
        DataManager.instance.nowPlayer.date = data;
        DataManager.instance.nowPlayer.count = count;
        //데이터를 인스턴스에 저장
        DataManager.instance.SaveData();
    }

    public void CountSlot()
    {
        NowData();
        DataManager.instance.FindSaveSlot(Nowname, Nowdate, Nowcount);
        SetUI();                  
        saveOption.SetActive(false);
    }
    //최근 파일부터 정렬

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
            else slotText[i].text = "비어있음";
        }
    }
    public void Print()
    {  
        CountSlot();
        saveOption.SetActive(false);

    }
}
