using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAtiveCon : MonoBehaviour
{
    public GameObject AObject;

    public TouchingMode LtouchingMode;
    public TouchingMode RtouchingMode;
    public TouchingMode LHtouchingMode;
    public TouchingMode RHtouchingMode;

    public bool Lt;
    public bool Rt;
    public bool LHt;
    public bool RHt;

    private void Update()
    {
        if (Lt == LtouchingMode && Rt == RtouchingMode && LHt == LHtouchingMode && RHt == RHtouchingMode)
        {
            AObject.SetActive(true);
        }
        else
        {
            AObject.SetActive(false);
        }
    }

}
