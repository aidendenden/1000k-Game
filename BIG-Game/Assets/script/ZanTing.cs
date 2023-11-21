using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZanTing : MonoBehaviour
{
    public GameManager _instance;
    public GameObject ZanTingG;

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
                ZanTingG.SetActive(true);
                isP = true;

            }

            else 
            {
                _instance.Unpause();
                ZanTingG.SetActive(false);
                isP = false;

            }

        }
    }

    public void back()
    {
        if (isP == true)
        {
            _instance.Unpause();
            ZanTingG.SetActive(false);
            isP = false;

        }
    }

    public void gotoMain()
    {
        if (isP == true)
        {
            _instance.Unpause();
            ZanTingG.SetActive(false);
            isP = false;
            SceneManager.LoadScene(0);


        }
    }
}
