using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchingMode : MonoBehaviour
{
    
    public bool IsAtive = false;
    public UnityEvent hitNote;

    private DingDong dingDong;
    private Collider2D con2d;
    // Start is called before the first frame update

    private void Start()
    {


        con2d = GetComponent<Collider2D>();
        dingDong = GetComponent<DingDong>();

        conOff();
    }
    public void IsNotAtive()
    {
        IsAtive = false;
    }

    public void IsDoAtive()
    {
        IsAtive = true;
    }
    public void conON()
    {
        con2d.enabled = true;
    }
    public void conOff()
    {
        con2d.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            dingDong.PlayAudioTwo();
            hitNote.Invoke();
        }
    }
}
