using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector3[] positions; // �洢�ĸ�λ������

    private void Start()
    {
      
        // ���ѡ��һ��λ������
        int randomIndex = Random.Range(0, 12);
        Vector3 randomPosition = positions[randomIndex];

        // �������ƶ������ѡ���λ������
        transform.position = randomPosition;
    }
}