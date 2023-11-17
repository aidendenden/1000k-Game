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
        
        if (Input.GetKey(AtiveKey))
        {
            if(isAtive == false) {
                bAnimator.SetTrigger("JumpIn");
                bAnimator.SetBool("OFFF", false);// 激活名为"ActivateAnimation"的触发器
                isAtive = true;
            }
        }  
        else {

            if(isAtive == true ||true) {
                bAnimator.SetBool("OFFF",true); // 激活名为"ActivateAnimation"的触发器
                isAtive = false;
            }
            
                
                
            
        }
            
            
        
    }
}