using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicPoint : MonoBehaviour

{
    public float point = 0;
    public float Combo = 0;

    public TextMeshProUGUI CCombo;
    public GameObject canvas;

    public void getpoint(int a)
    {
        Combo++;

        if (point + a <= 80) { point += a; }
        else { point = 80; }
    }

    public void lostpoint(int a)
    {
        Combo = 0;

        if (point - a >= 0) { point -= a; }
        else { point = 0; }
    }

    public void spawnCombo()
    {
        TextMeshProUGUI newTextMeshPro = Instantiate(CCombo, Vector3.zero, Quaternion.identity);
        newTextMeshPro.transform.SetParent(canvas.transform, false);

    }
}
