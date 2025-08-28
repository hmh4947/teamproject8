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
    private int dataCount=0;

    //씬 이름 정보 
    private string Nowname;
    //날짜 및 시간 
    private string Nowdate;
    //count
    private int Nowcount;

    public DateTime[] array = new DateTime[3];
    public DateTime dateTime1;
    public DateTime dateTime2;
    public DateTime dateTime3;

    void Start()
    {

        //저장된 데이터가 있는지 확인
        for (int i = 0; i < 3; i++)
        {
            //데이터가 있는경우
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
              
                //true로 변환
                savefile[i] = true;
                //선택한 슬롯 번호 저장
                DataManager.instance.nowSlot = i;
                //해당 슬롯 데이터 불러옴
                DataManager.instance.LoadData();
                //버튼에 날짜 및 시간 표현
                slotText[i].text = DataManager.instance.nowPlayer.date;

            }
            else
            {
                slotText[i].text = "비어있음";
            }
        }


    }
 
 
    public void PlayGame(string name)
    {
        
        //옵션창을 닫음
        int i;
        i = num;
       
        //현재 슬롯 번호가 true라면 
        if (File.Exists(DataManager.instance.path + $"{i}"))
        {
            if (savefile[i])
            {//버튼 클릭하면 현재 슬롯 인덱스를 받아
                
                // 그 인덱스의 정보를 저장
                name = DataManager.instance.nowPlayer.sceneIndex;
                //데이터 로드
                DataManager.instance.LoadData();
                //씬 로드
                SceneManager.LoadScene(name);
                Debug.Log("슬롯 정보가 있음 Scene Name: " + name);

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

        //count
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
    //저장될 Slot 위치를 결정
    public void CountSlot()
    {
        Debug.Log("카운트: " + count);
        for (int i = 0; i < 3; i++)
        {
            
            Debug.Log("루프" + i);
            DataManager.instance.nowSlot = i;
            //해당 슬롯 데이터 불러옴
            //데이터가 있다면
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {

                Debug.Log("데이터가 있다 다음 슬롯에");
                dataCount++;

            }
            //데이터가 없다면 저장
            if (!File.Exists(DataManager.instance.path + $"{i}"))
            { //현재 데이터를 받아오기
                NowData();
                //데이터 설정
                SetData(Nowname, Nowdate, Nowcount);
                break;
            }
        }
        Debug.Log("dataCount: " + dataCount);
        //데이터 수 카운트가 3이상이라면 비어있는 배열이 없기에 덮어쓰기
        if (dataCount >= 3)
        {
            Debug.Log("ㅇㅁㄹㄹㅇㅁ" );

            NowData();
            SetData(Nowname, Nowdate, Nowcount);
       
            DataManager.instance.SaveData();

        }
        dataCount=0;
        count++;
      
        //count를 늘려줌
        DataManager.instance.nowPlayer.count++;
    }
    //최근 파일부터 정렬
    public void SortSlot()
    {
       
        //데이터가 있는경우
        if (File.Exists(DataManager.instance.path + $"{0}"))
        {
            //시간 데이터를 가져옴
            DataManager.instance.LoadDataSlot(0);
            //해당 슬롯 데이터 불러옴

            dateTime1 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
            "yyyy/MM/dd/HH:mm:ss", null);
            array[0] = dateTime1;

            Debug.Log("dateData0 가져온 시간: " + dateTime1);
   
        }
        if (File.Exists(DataManager.instance.path + $"{1}"))
        {       //시간 데이터를 가져옴
            DataManager.instance.LoadDataSlot(1);
            dateTime2 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
            "yyyy/MM/dd/HH:mm:ss", null);
            array[1] = dateTime2;

            Debug.Log("dateData0 가져온 시간: " + dateTime2);
        
        }
        if (File.Exists(DataManager.instance.path + $"{2}"))
        {
            DataManager.instance.LoadDataSlot(2);
            dateTime3 = DateTime.ParseExact(DataManager.instance.nowPlayer.date,
               "yyyy/MM/dd/HH:mm:ss", null);
            array[2] = dateTime3;

            Debug.Log("dateData0 가져온 시간: " + dateTime3);

        }
        else
        {
            Debug.Log("데이터 없음");
        }

        //정렬
   
        Array.Sort(array);
        Debug.Log("정렬된 숫자: " + string.Join(", ", array));

       //정렬된 순서대로 슬롯에 넣기
    }
 
    public void Print()
    {  
        CountSlot();
      
        DataManager.instance.LoadData();
       // SortSlot();
        saveOption.SetActive(false);


    }
}
