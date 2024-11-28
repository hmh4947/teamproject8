using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;
    [SerializeField]
    float CameraMoveSpeed;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraPosition = new Vector3(0, 0, -10);
        playerTransform =GameObject.Find("Player").GetComponent<Transform>();
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;

    }
    private void FixedUpdate()
    {
        LimitCameraArea();
    }
    // Update is called once per frame
    void LimitCameraArea()
    {
        transform.position=Vector3.Lerp(transform.position, playerTransform.position+cameraPosition,Time.deltaTime* CameraMoveSpeed);
        float lx=mapSize.x-width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);
        float ly=mapSize.y-height;
        float clampY=Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);
        transform.position = new Vector3(clampX, clampY, -10f);
    }
  
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
