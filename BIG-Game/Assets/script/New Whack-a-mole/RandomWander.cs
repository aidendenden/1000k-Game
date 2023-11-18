using System;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 超级抽象的效果
/// </summary>
public class RandomWander : MonoBehaviour
{
    
    public Camera mainCamera;
    public float screenEdgeBuffer = 0.1f;

    public float speed = 2f; // 物体移动速度
    public Vector2 randomDirection;

    public float offset=1;

    private void Start()
    {
        randomDirection = Random.insideUnitCircle.normalized;
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
            randomDirection = -randomDirection;
            
            
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


        // 更新物体的位置
        transform.position = newPosition;
    }
    
    private bool CheckScreenEdge(Vector2 position)
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(position);

        // 检测是否超出屏幕边界
        if (screenPoint.x < screenEdgeBuffer || screenPoint.x > 1 - screenEdgeBuffer ||
            screenPoint.y < screenEdgeBuffer || screenPoint.y > 1 - screenEdgeBuffer)
        {
            return true;
        }

        return false;
    }
}