using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage1GameController : MonoBehaviour
{
    List<int> clickedButtonList;
    List<int> answerButtonList;

    public Text answerText;
    public answerBlinking bulb;
    int currentSequence;
    int currentMaxSequenceNumber;

    IEnumerator currCoroutine;
    /* 
    matching number in button list
    0: red
    1: green
    2: blue
    3: yellow
    */
    // Start is called before the first frame update
    void Start()
    {
        currentSequence = 0;
        clickedButtonList = new List<int>();
        answerButtonList = new List<int>();
        setAnswerButtonSequence(10);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void buttonClicked(int type){
        if(currentMaxSequenceNumber == currentSequence) return;
        clickedButtonList.Add(type);
        compareListToAnswer();
    }

    void setAnswerButtonSequence(int sequenceNumber){
        reset();
        resetAnswer();
        currentMaxSequenceNumber = sequenceNumber;
        for(int i=0; i<sequenceNumber; ++i){
            answerButtonList.Add(Random.Range(0,4));
        }
        updateTextUI();
        currCoroutine = showHint();
        StartCoroutine(currCoroutine);
    }

    void compareListToAnswer(){
        if(clickedButtonList[currentSequence].Equals(answerButtonList[currentSequence])){
            //correct
            Debug.Log("GOOD");
            currentSequence++;
        }else{
            //wrong
            Debug.Log("WRONG");
            StopCoroutine(currCoroutine);
            setAnswerButtonSequence(10);            
        }

        
    }

    void updateTextUI(){
        if(answerButtonList.Count == 0){
            answerText.text = "EMPTY";
        }else{
            answerText.text = "CURRENT: ";
            for(int i = 0; i < currentMaxSequenceNumber; ++i){
                int currentType = answerButtonList[i];
                
                switch(currentType){
                    case 0: // red
                        answerText.text += "<color=red>R</color> ";
                    break;

                    case 1: // greend
                        answerText.text += "<color=green>G</color> ";
                    break;

                    case 2: // blue
                        answerText.text += "<color=blue>B</color> ";
                    break;

                    case 3: // yellow
                        answerText.text += "<color=yellow>Y</color> ";
                    break;
                }
            }
        }        
    }


    IEnumerator showHint(){
        for(int i=0 ; i < currentMaxSequenceNumber; ++i){
           showBlinking(answerButtonList[i]);
           Debug.Log("Blinking " + i + answerButtonList[i]);
           yield return new WaitForSeconds(2f);
        }
    }

    void showBlinking(int type){
        bulb.startBlinking(type);
    }


    // reset
    void reset(){
        currentSequence = 0;
        clickedButtonList.Clear();
    }

    void resetAnswer(){
        answerButtonList.Clear();
    }
}
