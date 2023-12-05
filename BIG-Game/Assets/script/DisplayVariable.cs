using UnityEngine;
using TMPro;

public class DisplayVariable : MonoBehaviour
{
   // public MonoBehaviour yourScript; // ������Ľű���ʹ�� MonoBehaviour ���Ϳ��������κνű�
    public string variableName; // ��������
    public string QianZhui; // ����
    public TMP_Text textComponent; // TMP���
    private PointManager pointManager;

    private void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
    }

    void Update()
    {
        var field = pointManager.GetType().GetField(variableName); // ��ȡ�ű��еı���
        if (field != null)
        {
            var value = field.GetValue(pointManager); // ��ȡ������ֵ
            textComponent.text = QianZhui + value.ToString(); // ����TMP�����ʾ���ı�Ϊ������ֵ
        }
        else
        {
            textComponent.text = "Variable not found"; // ������������ڣ���ʾ������Ϣ
        }
    }
}