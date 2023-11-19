using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 超级抽象的效果
/// </summary>
public class RandomWander : MonoBehaviour
{

    public int Kind = 0;
    private float RunTime = 10;
    public Camera mainCamera;
    public float screenEdgeBuffer = 0.1f;
    public bool isHited = false;
    public float speed = 2f; // 物体移动速度
    public Vector2 randomDirection;

    public float offset=1;
    
    public float rotationSpeed = 5f; // 旋转速度
    private Vector2 targetDirection; // 目标旋转方向
    private Transform transform;

    private void Start()
    {
        randomDirection = Random.insideUnitCircle.normalized;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform = GetComponent<Transform>();

        float randomSize = Random.Range(0.5f, 0.8f); // 在指定区间内生成随机大小
        transform.localScale = new Vector3(randomSize, randomSize, randomSize); // 设置游戏物体的尺寸
        speed = Random.Range(5f, 9f);
        if (Kind == 1)
        {
            speed = speed * 1.5f;
        }
    }
    
    
    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     // 生成随机的移动方向
        //     randomDirection = Random.insideUnitCircle.normalized;
        // }
        
        
        // 计算物体的新位置
       
        Vector2 newPosition = (Vector2)transform.position + randomDirection * speed * Time.deltaTime;
        
        // 检测边界
        if (CheckScreenEdge(newPosition))
        {
            // 如果超出屏幕边界，则反向移动
           
            Vector3 direction = new Vector3(0,0,0) - gameObject.transform.position;

            // 如果你需要获取一个单位向量，你可以使用下面的代码
            Vector3 normalizedDirection = direction.normalized;

            randomDirection = normalizedDirection;


            // // 生成一个新的随机角度
            // float newAngle = Random.Range(0f, 360f);
            //
            // // 将新角度转换为方向向量
            // randomDirection = Quaternion.Euler(0f, 0f, newAngle) * Vector2.right;


            newPosition = (Vector2)transform.position + randomDirection * speed * Time.deltaTime;
        }
        else
        {
            if (Random.Range(1,100)<=offset)
            {
                randomDirection = Random.insideUnitCircle.normalized;
            }
        }

        if(Kind == 1)
        {
            if (RunTime <= 0)
            {
                Vector3 direction = new Vector3(0, 40, 0) - gameObject.transform.position;

                Vector3 normalizedDirection = direction.normalized;

                randomDirection = normalizedDirection;

                newPosition = (Vector2)transform.position + randomDirection * speed * 1.5f * Time.deltaTime;
            }
            else { RunTime -= Time.deltaTime; }
        }

        if (Kind == 0)
        {
            if (RunTime*1.5 <= 0)
            {
                Vector3 direction = new Vector3(0, 40, 0) - gameObject.transform.position;

                Vector3 normalizedDirection = direction.normalized;

                randomDirection = normalizedDirection;

                newPosition = (Vector2)transform.position + randomDirection * speed * 1.5f * Time.deltaTime;
            }
            else { RunTime -= Time.deltaTime; }
        }

        if (isHited) {

            Vector3 direction = new Vector3(0, 40, 0) - gameObject.transform.position;

            Vector3 normalizedDirection = direction.normalized;

            randomDirection = normalizedDirection;

            newPosition = (Vector2)transform.position + randomDirection * speed*1.5f * Time.deltaTime;

        }

        // 获取当前物体的移动方向
        Vector2 forwardDirection = GetComponent<RandomWander>().randomDirection;

        // 计算目标旋转角度
        float targetAngle = Mathf.Atan2(forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg;

        // 使用Slerp逐帧旋转物体朝向
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngle), rotationSpeed * Time.deltaTime);
        
        // 更新物体的位置
        transform.position = newPosition;
    }
    
    private bool CheckScreenEdge(Vector2 position)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(position);

        // 检测是否超出屏幕边界
        if (screenPoint.x < screenEdgeBuffer-0.2 || screenPoint.x > 1 - screenEdgeBuffer-0.2 ||
            screenPoint.y < screenEdgeBuffer+0.25 || screenPoint.y > 1 - screenEdgeBuffer-0.2)
        {
            return true;
        }

        return false;
    }


    public void BeHit()
    {
        isHited = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="CCC")
        {
            Destroy(gameObject);
        }
    }

}