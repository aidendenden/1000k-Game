using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZanTing : MonoBehaviour
{
    public GameManager _instance;

    public bool isP = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isP == false)
            {
                _instance.Pause();

            }

            if (isP == true)
            {
                _instance.Unpause();

            }

        }
    }
}
