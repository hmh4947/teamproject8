using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IBaseState<Player>
{
    private Player _player;
    // Start is called before the first frame update
    public void OperateEnter(Player sender)
    {
        _player = sender;
        _player.anim.SetBool("isJumping", true);
        _player.rigid.velocity = new Vector2(_player.rigid.velocity.x, 0f);
        _player.rigid.AddForce(Vector2.up * _player.jumpPower, ForceMode2D.Impulse);
  
    }
    public void OperateUpdate(Player sender)
    {
        float h = Input.GetAxisRaw("Horizontal");
        _player.rigid.velocity = new Vector2(h * _player.currentSpeed, _player.rigid.velocity.y);

        if (_player.rigid.velocity.y < 0 && _player.IsGrounded())
        {
            if (_player.IsGrounded())
            {
                _player.stateMachine.ChangeState(new Idle());
                return;
            }
               
        }
    }
    public void OperateExit(Player sender)
    {

        _player.anim.SetBool("isJumping", false);
    }
}
