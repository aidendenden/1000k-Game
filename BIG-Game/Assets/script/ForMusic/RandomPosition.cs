using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector3[] positions; // �洢�ĸ�λ������
    public Sprite[] Caizhi;

    private SpriteRenderer spr;
    private void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        // ���ѡ��һ��λ������
        int randomIndex = Random.Range(0, 12);
        Vector3 randomPosition = positions[randomIndex];

        // �������ƶ������ѡ���λ������
        transform.position = randomPosition;
        if (transform.position.x == -16)
        {
            spr.sprite = Caizhi[0];
        }
        if (transform.position.x == 14)
        {
            spr.sprite = Caizhi[1];
        }
        if (transform.position.x == -6)
        {
            spr.sprite = Caizhi[2];
        }
        if (transform.position.x == 4)
        {
            spr.sprite = Caizhi[3];
        }
    }
}