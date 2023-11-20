using System;
using UnityEngine;


/// <summary>
/// 在这个脚本里的Triggered方法决定传什么
/// </summary>
public class GameEventManager : MonoBehaviour
{
    private static readonly Lazy<GameEventManager> Lazy = new Lazy<GameEventManager>(() => new GameEventManager());

    private GameEventManager()
    {
        
    }

    public static GameEventManager Instance => Lazy.Value;

    public delegate void TriggerEventHandler(string message, Transform _transform,Vector3 v);

    public static event TriggerEventHandler OnTrigger;


    public void Triggered(string message, Transform _transform, Vector3 _vector3)
    {
        Debug.Log("Triggered: " + message);
        if (OnTrigger != null)
            OnTrigger(message, _transform, _vector3);
    }

    public void AddListener(TriggerEventHandler listener)
    {
        OnTrigger += listener;
    }

    public void RemoveListener(TriggerEventHandler listener)
    {
        OnTrigger -= listener;
    }
    private void HandleTrigger(string message,Transform _transform)
    {
        string t = "hello world";
        if (string.Equals(message, t))
        {
            Debug.Log("Trigger event received: " + message, _transform);
        }

    }
    
}


#region 监听交互的方法

// 以下是监听交互的方法
// void OnEnable()
// {
//    GameEventManager.OnTrigger += HandleTrigger;
// }
//
// void OnDisable()
// {
//      GameEventManager.OnTrigger -= HandleTrigger;
// }
//
//  private void HandleTrigger(string message,Transform _transform)
// {
//     string t = "hello world";
//     if (string.Equals(message, t))
//     {
//         Debug.Log("Trigger event received: " + message, _transform);
//     }
// }

#endregion

#region 以下是使用方法，发送事件

// GameEventManager.Instance.Triggered("to touch",transform);

#endregion