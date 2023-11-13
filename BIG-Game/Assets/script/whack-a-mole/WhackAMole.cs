using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMole : MonoBehaviour
{
    public List<Transform> allChildTransforms = new List<Transform>();

    void Start()
    {
        allChildTransforms = new List<Transform>(GetComponentsInChildren<Transform>(true));

        // 移除当前物体自身的Transform组件
        allChildTransforms.Remove(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
