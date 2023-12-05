using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZanTing : MonoBehaviour
{
   
    public GameObject ZanTingG;

    public bool isP = false;

    public bool isOld = false;


    public float timeDown = 1f;
    public int bottonHard = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (timeDown < 0)
        {
            if (bottonHard - 1 > 0)
            {
                bottonHard--;
            }
            else
            {
                bottonHard = 0;
            }
            timeDown = 1;
        }
        else
        {
            timeDown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isP == false)
            {
                GameManager.Instance.Pause();
                ZanTingG.SetActive(true);
                isP = true;

            }

            else 
            {
                GameManager.Instance.Unpause();
                ZanTingG.SetActive(false);
                isP = false;

            }

        }
    }

    public void back()
    {

        if (bottonHard >= 3)
        {
            if (isP == true)
            {
                GameManager.Instance.Unpause();
                ZanTingG.SetActive(false);
                isP = false;

            }
            
            bottonHard = 0;
        }
        else
        {
            bottonHard++;
        }

        
    }

    public void gotoMain()
    {

        if (bottonHard >= 3)
        {
            if (isP == true)
            {
                GameManager.Instance.Unpause();
                ZanTingG.SetActive(false);
                isP = false;
                SceneManager.LoadScene(0);


            }

            bottonHard = 0;
        }
        else
        {
            bottonHard++;
        }

       
    }
}
