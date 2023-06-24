using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public RuntimeAnimatorController up;
    public RuntimeAnimatorController down;
    public RuntimeAnimatorController left;
    public RuntimeAnimatorController Right;

    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAni(int key){ // left right down up
        switch(key){
            case 1:
                ani.runtimeAnimatorController = left;
            break;
            case 2:
                ani.runtimeAnimatorController = Right;
            break;
            case 3:
                ani.runtimeAnimatorController = down;
            break;
            case 4:
                ani.runtimeAnimatorController = up;
            break;
        }
        
    }
}
