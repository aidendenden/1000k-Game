using UnityEngine;

public class TigerAnimationController : MonoBehaviour
{
    private Animator bAnimator; // Tiger�Ķ���������
    public bool isAtive = false;
    public KeyCode AtiveKey = KeyCode.A;

    private void Start()
    {
        bAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        // ������W��A��S��D��ʱ�����
        if (Input.GetKey(AtiveKey))
        {
            if(isAtive == false) {
                bAnimator.SetTrigger("JumpIn"); // ������Ϊ"ActivateAnimation"�Ĵ�����
                isAtive = true;
            }
        }  
        else {
            if (isAtive)
            {
                
                bAnimator.SetTrigger("Off"); // ������Ϊ"ActivateAnimation"�Ĵ�����
                isAtive = false;
            }
        }
            
            
        
    }
}