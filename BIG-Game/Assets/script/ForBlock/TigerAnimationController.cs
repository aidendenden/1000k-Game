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
        
        if (Input.GetKey(AtiveKey))
        {
            if(isAtive == false) {
                bAnimator.SetTrigger("JumpIn");
                bAnimator.SetBool("OFFF", false);// ������Ϊ"ActivateAnimation"�Ĵ�����
                isAtive = true;
            }
        }  
        else {

            if(isAtive == true ||true) {
                bAnimator.SetBool("OFFF",true); // ������Ϊ"ActivateAnimation"�Ĵ�����
                isAtive = false;
            }
            
                
                
            
        }
            
            
        
    }
}