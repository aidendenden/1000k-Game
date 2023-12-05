using UnityEngine;
using TMPro;

public class DisplayNumberWithTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // ����TextMeshPro����
    public float numberValue; // Ҫ��ʾ�����ֱ���

    public MusicPoint musicPoint;
    private Animator aniCombo;

    private PointManager pointManager;

   
    // ��ÿ֡�����и���TextMeshPro��ʾ��ֵ

    private void Start()
    {
        
            musicPoint = GameObject.FindGameObjectWithTag("PManager").GetComponent<MusicPoint>();
            aniCombo = GetComponent<Animator>();
        
      


    }


    public void conboo()
    {
        aniCombo.SetTrigger("Combo");
    }

    public void newCombo()
    {
        textMeshPro.text = musicPoint.Combo.ToString(); // �����ֱ�����ֵ��ʾ��TextMeshPro��
    }
}