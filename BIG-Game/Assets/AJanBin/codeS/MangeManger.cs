using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangeManger : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1f)]
    public float Hard = 1;

    public int numberOne = 1;
    public int numberTwo = 1;


    public float shrinkThreshold = 50f;
    public float moveSpeed = 50f;
    public float shrinkSpeed = 5f;

    public Animator Eye;
    public GameObject Stop;
    private PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
        pointManager.TouZiZero();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed - shrinkSpeed * Time.deltaTime > shrinkThreshold)
        {
            moveSpeed -= shrinkSpeed * Time.deltaTime;
        }
        pointManager.addTime(Time.deltaTime);
    }

    public void Stopp()
    {
        Stop.SetActive(true);
        Eye.SetTrigger("stop");
    }

    public void Starr()
    {
        Stop.SetActive(false);
    }
}
