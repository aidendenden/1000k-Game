using UnityEngine;

public class TigerAnimationController : MonoBehaviour
{
    private Animator bAnimator; // Tiger的动画控制器
    public bool isAtive = false;
    public KeyCode AtiveKey = KeyCode.A;

    private void Start()
    {
        bAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        // 当按下W、A、S或D键时激活动画
        if (Input.GetKey(AtiveKey))
        {
            if(isAtive == false) {
                bAnimator.SetTrigger("JumpIn"); // 激活名为"ActivateAnimation"的触发器
                isAtive = true;
            }
        }  
        else {
            if (isAtive)
            {
                
                bAnimator.SetTrigger("Off"); // 激活名为"ActivateAnimation"的触发器
                isAtive = false;
            }
        }
            
            
        
    }
}