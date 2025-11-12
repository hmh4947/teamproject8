using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour,IBaseState<Player>
{
    private Player _player;
    // Start is called before the first frame update
    public void OperateEnter(Player sender)
    {
        _player = sender;
        _player.anim.SetBool("isRunning", true);

        _player.currentSpeed = _player.runSpeed;
    }
    public void OperateUpdate(Player sender)
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && _player.IsGrounded())
        {
            _player.stateMachine.ChangeState(new Jump());
            return;

        }
      
        if (!_player.runToggle)
        {
            _player.stateMachine.ChangeState(new Walk());
            return;
        }
        

        if (Mathf.Abs(h) < 0.1f)
        {
            _player.stateMachine.ChangeState(new Idle());
            return;
        }
        _player.rigid.velocity = new Vector2(h * _player.currentSpeed, _player.rigid.velocity.y);

        // 방향 전환
        if (h != 0)
        {
            _player.spriteRenderer.flipX = h < 0;

        }
    }
    public void OperateExit(Player sender)
    {
        _player.anim.SetBool("isRunning", false);
    }
}
