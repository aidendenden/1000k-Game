using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 5f);
    }
}