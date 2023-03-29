using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIntake : MonoBehaviour
{
    public Transform golfBall;
    public Rigidbody golfBallRigidBody;
    public Transform target1;
    public Transform target2;

    public float speed;
    bool goIntoPipe;

    public float exitThrust;
    public float pipeSwitchTime;
    public float preExitTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        golfBallRigidBody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (goIntoPipe)
        {
            golfBall.position = Vector3.MoveTowards(golfBall.position, target1.position, step);
        }

        if (golfBall.position == target1.position)
        {
            goIntoPipe = false;

            if (timer < pipeSwitchTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                golfBall.position = target2.position;
                golfBall.rotation = target2.rotation;
                timer = 0;
            }
        }

        if (golfBall.position == target2.position)
        {
            if (timer < preExitTime)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    golfBallRigidBody.isKinematic = false;
                    golfBallRigidBody.AddForce(transform.forward * exitThrust);
                    timer = 0;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goIntoPipe = true;
            golfBallRigidBody.isKinematic = true;
        }
    }
}
