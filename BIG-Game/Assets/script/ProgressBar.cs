using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider; // ����Slider����
    public MusicPoint musicPoint;
  

    // ���ý�������ֵ
    public void SetProgress(float value)
    {
        slider.value = value;
    }

    // ���ý����������ֵ
    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = 0; // ȷ���������ĳ�ʼֵ�������ֵ
    }
    private void Start()
    {
        SetMaxValue(80);
    }
    private void Update()
    {
        SetProgress(musicPoint.point);
    }
}