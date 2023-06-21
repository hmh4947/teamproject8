using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage1GameController : MonoBehaviour
{
    List<int> clickedButtonList;
    List<int> answerButtonList;

    public Text answerText;


    int currentSequence;
    int currentMaxSequenceNumber;
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
    }

    void compareListToAnswer(){
        if(clickedButtonList[currentSequence].Equals(answerButtonList[currentSequence])){
            //correct
            Debug.Log("GOOD");
            currentSequence++;
        }else{
            //wrong
            Debug.Log("WRONG");
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
                        Debug.Log(currentType);
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


    // reset
    void reset(){
        currentSequence = 0;
        clickedButtonList.Clear();
    }

    void resetAnswer(){
        answerButtonList.Clear();
    }
}
