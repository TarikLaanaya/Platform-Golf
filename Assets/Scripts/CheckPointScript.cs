using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [Header("Put child with collider in not parent")] // could definitley fix this but would be a waste of time right now, however could fix in the future to help speed of level development
    public GameObject[] checkPointColliders;

    public int checkPointNumber = 0;
    public int previousNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (checkPointColliders.Length > checkPointNumber)
        {
            if (other.gameObject == checkPointColliders[checkPointNumber])
            {
                checkPointNumber ++;
            }
        }
    }
}
