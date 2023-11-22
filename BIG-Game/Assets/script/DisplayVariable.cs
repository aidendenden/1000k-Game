using UnityEngine;
using TMPro;

public class DisplayVariable : MonoBehaviour
{
   // public MonoBehaviour yourScript; // 引用你的脚本，使用 MonoBehaviour 类型可以引用任何脚本
    public string variableName; // 变量名称
    public string QianZhui; // 名称
    public TMP_Text textComponent; // TMP组件
    private PointManager pointManager;

    private void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
    }

    void Update()
    {
        var field = pointManager.GetType().GetField(variableName); // 获取脚本中的变量
        if (field != null)
        {
            var value = field.GetValue(pointManager); // 获取变量的值
            textComponent.text = QianZhui + value.ToString(); // 更新TMP组件显示的文本为变量的值
        }
        else
        {
            textComponent.text = "Variable not found"; // 如果变量不存在，显示错误信息
        }
    }
}