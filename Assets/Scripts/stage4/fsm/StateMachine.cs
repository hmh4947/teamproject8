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
        if (m_sender == null) return;
        if (CurrState == state) return;
        if (CurrState != null)
            CurrState.OperateExit(m_sender);
        CurrState = state;  
        //새 상태의 Enter를 호출
        if (CurrState != null)
            CurrState.OperateEnter(m_sender);
    }
    public void ChangeState(IBaseState<T> newState)
    {
        SetState(newState);
    }
    //Update 역할
    public void DoOperateUpdate()
    {
        if (m_sender == null) return;
        CurrState.OperateUpdate(m_sender);
    }

}
