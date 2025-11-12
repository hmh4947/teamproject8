using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class StateMachine<T>
{
    private T m_sender;
    public IBaseState<T> CurrState { get; set; }
    public StateMachine(T sender,IBaseState<T> state)
    {
        m_sender = sender;
        SetState(state);
    }
    public void SetState(IBaseState<T> state)
    {
        

        // null에러출력
        if (m_sender == null)
        {
          
            return;
        }

        if (CurrState == state)
        {
       
            return;
        }

        if (CurrState != null)
            CurrState.OperateExit(m_sender);

        //상태 교체.
        CurrState = state;

        //새 상태의 Enter를 호출한다.
        if (CurrState != null)
            CurrState.OperateEnter(m_sender);

     

    }
    public void ChangeState(IBaseState<T> newState)
    {
        SetState(newState);
    }

    //State용 Update 함수.
    public void DoOperateUpdate()
    {
        if (m_sender == null)
        {
          
            return;
        }
        CurrState.OperateUpdate(m_sender);
    }

}
