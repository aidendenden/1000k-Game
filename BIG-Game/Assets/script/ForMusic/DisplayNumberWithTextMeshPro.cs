using UnityEngine;
using TMPro;

public class DisplayNumberWithTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // 引用TextMeshPro对象
    public float numberValue; // 要显示的数字变量

    public MusicPoint musicPoint;
    private Animator aniCombo;

    private PointManager pointManager;

   
    // 在每帧更新中更新TextMeshPro显示的值

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
        textMeshPro.text = musicPoint.Combo.ToString(); // 将数字变量的值显示在TextMeshPro上
    }
}