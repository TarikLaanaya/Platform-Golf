using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrajectory : MonoBehaviour
{
    public RectTransform targetRectArea;

    public AddForceToBall addForceToBall;

    public bool inside;
    private bool wasInside;

    Touch touch;

    void Awake()
    {
        inside = false;
        wasInside = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (wasInside && !inside)
            {
                wasInside = false;
            }
        }

        if (RectTransformUtility.RectangleContainsScreenPoint (targetRectArea, touch.position, Camera.main))
        {
            inside = true;
        }
        else
        {
            inside = false;
        }

        if (inside && !wasInside)
        {
            wasInside = true;
        }
    }
}
