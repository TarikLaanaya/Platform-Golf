using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToBall : MonoBehaviour
{
    public Audio audioScript;
    Rigidbody ballRigidbody;
    public float maxThrust = 20f;
    float thrust;
    float thrustTimer;
    public float thrustPerSecond;

    public GameObject pointPrefab;
    public GameObject[] points;
    public int numberOfPoints;
    Vector3 direction;

    public Transform fingerLocator;

    float distToGround;
    bool isGrounded;
    float groundedTimer;
    public float timeBeforeGrounded;
    bool groundedForTime;

    public bool canMove;

    public DeleteTrajectory deleteTrajectory;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();

        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity); //Spawn points which will show ball trajectory (number of points is controlled by the variable "numberOfPoints")
            points[i].transform.parent = transform;
        }

        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
    
    void Update ()
    {
        if (canMove)
        {
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

            if (Input.touchCount > 0)
            {
                if (groundedForTime)
                {
                    fingerLocator.gameObject.SetActive(true);
                }

                Touch touch = Input.GetTouch(0);

                Vector3 mousePosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
                Vector3 mousePosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                
                Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
                Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

                //We calculate the point the player pressed the screen on the near plane and far plane of the camera so we can create an accurate raycast

                Debug.DrawLine(mousePosN, mousePosF-mousePosN, Color.red);
                
                RaycastHit hit;

                int layerMask = 1 << 8;
                //layerMask = ~layerMask;

                if (Physics.Raycast(mousePosN, mousePosF-mousePosN, out hit, Mathf.Infinity, layerMask)) //Raycast from player finger (using previous calculations) and collides with an invisible plane which provides the hit result
                {
                    transform.LookAt(hit.point);
                    direction = hit.point - transform.position;
                    fingerLocator.transform.position = hit.point;
                }

                switch (touch.phase)
                {
                    case TouchPhase.Ended: //Player lifted finger
                        if (groundedForTime & !deleteTrajectory.inside)
                        {
                            ballRigidbody.velocity = transform.forward * thrust; //add force
                            audioScript.GolfBallHit();
                            audioScript.golfBallAudio.PlayOneShot(audioScript.golfBounce, 0.7f);     
                        }
                        thrustTimer = 0f;
                        thrust = 0f;
                        break;
                }
            }
            else
            {
                fingerLocator.gameObject.SetActive(false);
            }

            for (int i = 0; i < points.Length; i++)
            {   
                if (groundedForTime)
                {
                    points[i].transform.position = PointPosition(i * 0.05f); //change the position of each point to represent the trajectory
                    if (Input.touchCount > 0)
                    {
                        points[i].SetActive(true);
                    }
                    else
                    {
                        points[i].SetActive(false);
                    }
                }
                else
                {
                    points[i].SetActive(false);
                }
            }
        }
        else
        {
            thrust = 0;
            for (int i = 0; i < points.Length; i++)
            {
                points[i].SetActive(false);
            }
        }        
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (isGrounded)
            {
                if (groundedTimer < timeBeforeGrounded) //make sure player is grounded for a while before they can move
                {
                    groundedTimer += 0.01f;
                }
                else
                {
                    groundedForTime = true;
                }      
            }
            else
            {
                groundedTimer = 0;
                groundedForTime = false;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (thrust <= maxThrust && groundedForTime) //controls the slow increase in thrust as the player holds down their finger
                {
                    thrustTimer += Time.deltaTime;
                    if (thrustTimer >= 0.01f)
                    {
                        thrust += thrustPerSecond / thrustTimer;
                        thrustTimer = 0f;
                    }
                }
            }
        }
    }

    Vector3 PointPosition(float t)
    {
        Vector3 currentPointPos = (Vector3)transform.position + (direction.normalized * thrust * t) + 0.5f * Physics.gravity * (t*t); //Set the trajectory point position based on the thrust and direction
        
        return currentPointPos;
    }
}