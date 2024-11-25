using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuFalse : MonoBehaviour
{
    private Button ReGameBtn, SoundBtn, KeyboardBtn, ScreenBtn, SaveBtn, LoadBtn, ExitBtn;
   

    // Start is called before the first frame update
    void Start()
    {
        ReGameBtn = GameObject.Find("ReGameBtn").GetComponent<Button>();
        SoundBtn = GameObject.Find("SoundBtn").GetComponent<Button>();
        KeyboardBtn = GameObject.Find("KeyboardBtn").GetComponent<Button>();
        ScreenBtn = GameObject.Find("ScreenBtn").GetComponent<Button>();
        SaveBtn = GameObject.Find("SaveBtn").GetComponent<Button>();
        LoadBtn = GameObject.Find("LoadBtn").GetComponent<Button>();
        ExitBtn = GameObject.Find("ExitBtn").GetComponent<Button>();

    }
   
    // Update is called once per frame
    void Update()
    {

    }

    public void btnNo()
    {

        ReGameBtn.interactable = false;
        SoundBtn.interactable = false;
        KeyboardBtn.interactable = false;
        ScreenBtn.interactable = false;
        SaveBtn.interactable = false;
        LoadBtn.interactable = false;
        ExitBtn.interactable = false;


    }
}