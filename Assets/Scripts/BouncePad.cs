using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bouncePadPower;

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
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 dir = collision.contacts[0].normal;
        if(rb != null){
            rb.AddForce(dir * bouncePadPower, ForceMode.Impulse);
        }
    }
}
