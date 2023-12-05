using UnityEngine;
using UnityEngine.Events;

public class RandomPositionInPlane : MonoBehaviour
{
    public Transform point1; // ��һ�������
    public Transform point2; // �ڶ��������
    public TimerExample timerrr;
    public UnityEvent Full;
    private PointManager pointManager;

    public float DanZhuPoint = 0;

    private float PointPass = 0;

    private void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
    }
    public void change()
    {
        // ����������㹹�ɵ�ƽ�������ѡ��һ����
        Vector3 randomPosition = Vector3.Lerp(point1.position, point2.position, Random.value);

        // ������Ϸ���岢������λ��
        
        gameObject.transform.position = randomPosition;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WW")
        {
            PointPass++;
            DanZhuPoint++;
        }
    }


    private void Update()
    {
        if(PointPass >= 10)
        {
            PointPass = 0;
            change();
            timerrr.timer = 0f;
            Full.Invoke();
            pointManager.addDanZhuScore();
        }
    }
}