using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    // public int nextMove;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(-1, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayhit = Physics2D.Raycast(frontVec,
            Vector3.down, 1, LayerMask.GetMask("Platform"));


        if (rayhit.collider != null)
        {
            nextMove = nextMove * (-1); 
            CancelInvoke(); 
            Invoke("Think", 5);
        }

    }
    void Think()
    {// (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

       
        nextMove = Random.Range(-1, 2);
        float time = Random.Range(2f, 5f);
        Invoke("Think", 5); 
    }

}
