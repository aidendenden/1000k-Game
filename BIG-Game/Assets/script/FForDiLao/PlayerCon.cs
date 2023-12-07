using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public float stepDistance = 1f; // 走一步的距离
    public float rotationStep = 90f; // 旋转的角度
    public float moveDuration = 0.5f; // 移动或旋转所需的时间
    [SerializeField]
    private bool isMoving = false; // 是否正在移动或旋转的标志

    public float HuaDongMingGan = 5;
    [SerializeField]
    private float HuaDongMingGanP;

    public float HuaDongMingGan2 = 5;
    [SerializeField]
    private float HuaDongMingGanP2;


    public float HuaDongMingGan3 = 5;
    [SerializeField]
    private float HuaDongMingGanP3;

    public float HuaDongMingGan4 = 5;
    [SerializeField]
    private float HuaDongMingGanP4;

    public float HuaDongDown = 3;
    [SerializeField]
    private bool loockU = false;
    [SerializeField]
    private bool loockD = false;
    [SerializeField]
    private bool loockL = false;
    [SerializeField]
    private bool loockR = false;




    private void Start()
    {
        HuaDongMingGanP = HuaDongMingGan;
    }

    private void Update()
    {
        if (HuaDongMingGanP < HuaDongMingGan)
        {
            HuaDongMingGanP += Time.deltaTime*HuaDongDown;
        }
        if (HuaDongMingGanP2 < HuaDongMingGan2)
        {
            HuaDongMingGanP2 += Time.deltaTime * HuaDongDown;
        }
        if (HuaDongMingGanP3 < HuaDongMingGan3)
        {
            HuaDongMingGanP3 += Time.deltaTime * HuaDongDown/5;
        }
        if (HuaDongMingGanP4< HuaDongMingGan4)
        {
            HuaDongMingGanP4 += Time.deltaTime * HuaDongDown/5;
        }
    }

    public void HuaDongC()
    {
        HuaDongMingGanP = HuaDongMingGan;
        HuaDongMingGanP2 = HuaDongMingGan2;
        HuaDongMingGanP3 = HuaDongMingGan3;
        HuaDongMingGanP4 = HuaDongMingGan4;

        loockR = false;
        loockL = false;
        loockU = false;
        loockD = false;


    }

    public void HuaDongD()
    {
        HuaDongMingGanP = 999999;
        HuaDongMingGanP2 = 999999;
        HuaDongMingGanP3 = 999999;
        HuaDongMingGanP4 = 999999;

        loockR = true;
        loockL = true;
        loockU = true;
        loockD = true;


    }

    public void HuaDongR()
    {

        HuaDongMingGanP4 = HuaDongMingGan4;
        HuaDongMingGanP2 = HuaDongMingGan2;
        HuaDongMingGanP3 = HuaDongMingGan3;
        loockL = true;
        loockU = true;
        loockD = true;
        if (loockR == false)
        {
            if (HuaDongMingGanP <= 0)
            {
               //TurnRight();
                HuaDongMingGanP = 9999999;
            }
            else
            {
                HuaDongMingGanP--;
            }
        }
        

    }

    public void HuaDongL()
    {

        HuaDongMingGanP = HuaDongMingGan;
        HuaDongMingGanP4 = HuaDongMingGan4;
        HuaDongMingGanP3 = HuaDongMingGan3;
        loockR = true;
        loockU = true;
        loockD = true;
        if (loockL == false)
        {
            if (HuaDongMingGanP2 <= 0)
            {
                //TurnLeft();
                HuaDongMingGanP2 = 9999999;
            }
            else
            {
                HuaDongMingGanP2--;
            }

        }
        

    }



    public void HuaDongUp()
    {
        HuaDongMingGanP = HuaDongMingGan;
        HuaDongMingGanP2 = HuaDongMingGan2;
        HuaDongMingGanP4 = HuaDongMingGan4;
        loockR = true;
        loockL = true;
        loockD = true;
        if (loockU == false)
        {
            if (HuaDongMingGanP3 <= 0)
            {
                //MoveForward();
                HuaDongMingGanP3 = 9999999;
            }
            else
            {
                HuaDongMingGanP3--;
            }
        }
        

    }

    public void HuaDongDn()
    {
        HuaDongMingGanP = HuaDongMingGan;
        HuaDongMingGanP2 = HuaDongMingGan2;
        HuaDongMingGanP3 = HuaDongMingGan3;
        loockR = true;
        loockL = true;
        loockU = true;
        if (loockD == false)
        {
            if (HuaDongMingGanP4 <= 0)
            {
                //MoveForward();
                HuaDongMingGanP4 = 9999999;
            }
            else
            {
                HuaDongMingGanP4--;
            }
        }


    }



    // 向左转90度
    public void TurnLeft()
    {
        if (!isMoving)
        {
            StartCoroutine(RotateOverTime(Vector3.up, -rotationStep));
        }
    }

    // 向右转90度
    public void TurnRight()
    {
        if (!isMoving)
        {
            StartCoroutine(RotateOverTime(Vector3.up, rotationStep));
        }
    }

    // 向前进一步
    public void MoveForward()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveOverTime(transform.forward * stepDistance));
        }
    }

    // 向后退一步
    public void MoveBackward()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveOverTime(-transform.forward * stepDistance));
        }
    }

    private IEnumerator RotateOverTime(Vector3 axis, float angle)
    {
        isMoving = true;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(axis * angle);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isMoving = false;
    }

    private IEnumerator MoveOverTime(Vector3 offset)
    {
        isMoving = true;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = transform.position + offset;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
