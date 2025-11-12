using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump

    }
    public float maxSpeed;
    public float jumpPower;
    public float runSpeed;
    public float currentSpeed;
    private bool walking = true;
    public Transform PlayerT;
    public GameObject LaserObj;
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public float LaserDistance = 5.0f;
    private GameManager InstantiateObj;
    public GameObject PlayerObj;
    public Transform EnemyT;
    public bool runToggle;
    private bool isUpateLaser=false;

    private GameObject _laser;
    private Camera _cam;
    public StateMachine<Player> stateMachine{ get; private set; }


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        stateMachine = new StateMachine<Player>(this, new Idle());
        _cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            runToggle = !runToggle;
        }    
        stateMachine.DoOperateUpdate();

        if (isUpateLaser) { DrawLaser();}

    }
   

   
    
    public bool IsGrounded()
    {
        

        RaycastHit2D rayhit = Physics2D.Raycast(
            rigid.position,
            Vector2.down,
            1.0f,
            LayerMask.GetMask("Platform")
        );

        Debug.DrawRay(rigid.position, Vector2.down *1.0f, Color.green);

        return rayhit.collider != null && rayhit.distance <1.0f;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        IHealth health = gameObject.GetComponent<IHealth>();
        if (collision.gameObject.tag == "Enemy")
        {
          //  SceneManager.LoadScene("Stage4");
            // Debug.Log("재시작");
            
            if (health != null)
            {
                //stage4 재시작
                health.Death();
                Debug.Log("재시작");
            }
           

        }


        IItem item = collision.gameObject.GetComponent<IItem>();
        if (item != null)
        {
           item.TakeItem();
            EnemyController enemy = EnemyT.GetComponent<EnemyController>();
            if (enemy != null && _laser != null)
            {
                enemy.SetLaserTarget(_laser.transform);
                
                Debug.Log("충돌");
            }
            // DrawLaser();
            isUpateLaser = true;
        }
        
    }
    public GameObject getLaser() {  return _laser; }
    void DrawLaser()
    {

        if (_cam == null || PlayerT == null || LaserObj == null) return;

  
        Vector3 mousePos = Input.mousePosition;
        if (!_cam.orthographic)
        {
            float depth = Mathf.Abs(_cam.transform.position.z - PlayerT.position.z);
            mousePos.z = depth;
        }
        else
        {
       
            mousePos.z = Mathf.Abs(_cam.transform.position.z - PlayerT.position.z);
        }

        Vector3 worldMouse = _cam.ScreenToWorldPoint(mousePos);
        worldMouse.z = PlayerT.position.z;

        // 2) 방향 & 거리 제한
        Vector3 dir = worldMouse - PlayerT.position;
        if (dir.sqrMagnitude > LaserDistance * LaserDistance)
            dir = dir.normalized * LaserDistance;

        Vector3 targetPos = PlayerT.position + dir;

        //처음 한 번만 생성, 이후 위치/회전 갱신
      
        if (_laser == null)
        {
            _laser = Instantiate(LaserObj, targetPos, Quaternion.identity);
            _laser.tag = "Laser";
            _laser.transform.SetParent(null, true);
            EnemyController enemy = FindObjectOfType<EnemyController>();
            if(enemy != null)
               {
                enemy.SetLaserTarget(_laser.transform);
            }
        }
        _laser.transform.position = targetPos;

        // 마우스 방향으로 회전
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _laser.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}





