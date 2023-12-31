using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutter : MonoBehaviour
{  
    public List<GameObject> image = new List<GameObject>();
    
    public void FlutterImage(int index)
    {
        if (index>=image.Count)
        {
            return;
        }
        for (int i = 0; i < index; i++)
        {
            StartCoroutine(SetShow(i));
        }
    }

   
    IEnumerator SetShow(int i)
    {
        image[i].SetActive(true);
        yield return new WaitForSeconds(10.0f);
        image[i].SetActive(false);
    }
}
