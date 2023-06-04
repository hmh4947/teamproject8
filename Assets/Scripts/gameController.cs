using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameController : MonoBehaviour
{
    
    public Text text;
    public Text combo;
    bouncyText comboText;
    int score = 0;
    int ArrowTimer = 70;
    int ArrowType = 0;
    int combos = 0;
    
    bool LeftPressed = false;
    bool RightPressed = false;
    bool UpPressed = false;
    bool DownPressed = false;
    bool anyKeyPressed = false;
    bool isFever = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        comboText = FindObjectOfType<bouncyText>();
        SetText();        
    }

    // Update is called once per frame
    void Update()
    {
        if(ArrowTimer > 0){
            ArrowTimer -= 1;
        }            
        else if (ArrowTimer == 0){
            resetTimer();
        }
        
        LeftPressed = false;
        RightPressed = false;      
        UpPressed = false;
        DownPressed = false;
        anyKeyPressed = false;
        if(Input.anyKey){
            if(Input.GetKey(KeyCode.LeftArrow)){
                LeftPressed = true;
                anyKeyPressed = true;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                RightPressed = true;
                anyKeyPressed = true;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                DownPressed = true;
                anyKeyPressed = true;
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                UpPressed = true;
                anyKeyPressed = true;
            }
        }


    }

    public void resetTimer() {
        ArrowTimer = Random.Range(20,60);
        ArrowType = Random.Range(0,4);
    }


    // getter setter
    public void GetScore(int type){
        int addScore;
        switch(type){
            case 0:   // perfect
                addScore = 3;
                combos += 1;
                comboText.reset();
                Debug.Log("perfect");
                break;
            case 1: // good
                addScore = 2;
                combos += 1;
                comboText.reset();
                Debug.Log("good");
                break;
            case 2: // bad
                addScore = 1;
                isFever = false;
                combos = 0;
                Debug.Log("bad");
                break;
            case 4: // miss
                addScore = 0;
                isFever = false;
                combos =0;
                Debug.Log("miss");
                break;
            default:
                addScore = 0;
                break;
        }
        if(isFever) addScore *= 2;
        this.score += addScore;
        SetText();
    }

    // set Score to Text
    public void SetText(){
        text.text = "Score: " + score.ToString(); 
        if(combos != 0){
            combo.color = Color.black;
            combo.text = combos.ToString() + " COMBO";
        }
        else{
            combo.color = Color.clear;
        }
        
    }

    public int getTimer() 
    {
        return ArrowTimer;
    }

    public int getArrowType(){
        return ArrowType;
    }

    public bool isLeftPressed() {return LeftPressed;}
    public bool isRightPressed() {return RightPressed;}
    public bool isDownPressed() {return DownPressed;}
    public bool isUpPressed() {return UpPressed;}
    public bool isAnykeyPressed() {return anyKeyPressed;}
}
