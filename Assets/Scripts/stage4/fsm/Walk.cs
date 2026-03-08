using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Walk : MonoBehaviour,IBaseState<Player>
{
    private Player _player;
    // Start is called before the first frame update
    public void OperateEnter(Player sender)
    {
        _player = sender;
        _player.anim.SetBool("isWalking", true);
        _player.currentSpeed = _player.maxSpeed;
    }
    public void OperateUpdate(Player sender)
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(h) < 0.1)
        {
           _player.stateMachine.ChangeState(new Idle());
          
        }

        //Directoin sprite
        if (_player.runToggle)
        {
            _player.stateMachine.ChangeState(new Run());
           
            return;

        }
        if (Input.GetButtonDown("Jump") && _player.IsGrounded())
        {
            _player.stateMachine.ChangeState(new Jump());
            return;

        }


        _player.rigid.velocity = new Vector2(h * _player.currentSpeed, _player.rigid.velocity.y);
        if (h != 0)
        {
            _player.spriteRenderer.flipX = h < 0;
        }

    }
    public void OperateExit(Player sender)
    {
        _player.anim.SetBool("isWalking", false);
    }
}
