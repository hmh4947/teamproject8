using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameController : MonoBehaviour
{
    
    public Text text;
    public Text combo;
    public playerAnimationController playerAni;
    public arrowMaker left;
    public arrowMaker down;
    public arrowMaker right;
    public arrowMaker up;
    bouncyText comboText;
    int score = 0;
    float ArrowTimer = 30;
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
        comboText = FindObjectOfType<bouncyText>();
        SetText();        
        gameUIcontroller.currentGear = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(ArrowTimer > 0){
            ArrowTimer -= Time.deltaTime*12;
        }            
        else if (ArrowTimer < 0){
            switch(ArrowType){
                case 0:
                left.SpawnArrow();
                break;
                case 1:
                down.SpawnArrow();
                break;
                case 2:
                right.SpawnArrow();
                break;
                case 3:
                up.SpawnArrow();
                break;
            }
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
                playerAni.changeAni(1);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                RightPressed = true;
                anyKeyPressed = true;
                playerAni.changeAni(2);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                DownPressed = true;
                anyKeyPressed = true;
                playerAni.changeAni(3);
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                UpPressed = true;
                anyKeyPressed = true;
                playerAni.changeAni(4);
            }
        }


    }

    public void resetTimer() {
        ArrowTimer = Random.Range(20,30);
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

    public float getTimer() 
    {
        return ArrowTimer;
    }

    public int getArrowType(){
        return ArrowType;
    }

    public int getCombo() {return combos;}

    public bool isLeftPressed() {return LeftPressed;}
    public bool isRightPressed() {return RightPressed;}
    public bool isDownPressed() {return DownPressed;}
    public bool isUpPressed() {return UpPressed;}
    public bool isAnykeyPressed() {return anyKeyPressed;}
}
