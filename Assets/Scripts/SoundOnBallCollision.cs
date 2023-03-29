using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnBallCollision : MonoBehaviour
{
    public Audio audioScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        audioScript.GolfBallBounce();
    }
}
