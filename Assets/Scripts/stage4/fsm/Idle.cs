using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour, IBaseState<Player>
{
    private Player _player;
    // Start is called before the first frame update
    public void OperateEnter(Player sender)
    {
        _player = sender;
        if (_player != null)
        {
            _player.currentSpeed = 0;
            _player.anim.SetBool("isJumping", false);
            _player.anim.SetBool("isWalking", false);
            _player.anim.SetBool("isRunning", false);
        }
    }
    public void OperateUpdate(Player sender)
    {
        float h = Input.GetAxisRaw("Horizontal");

       if (Mathf.Abs(h)>0.1f)
       {
            if(_player.runToggle)
            {
                _player.stateMachine.ChangeState(new Run());

            }
            else
            {
                _player.stateMachine.ChangeState(new Walk());

            }
            return;
       }
       if(Input.GetButtonDown("Jump")&&_player.IsGrounded())
        {
            _player.stateMachine.ChangeState(new Jump());
            return;

        }
        
    }
    public void OperateExit(Player sender)
    {
    }
}
