using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.InputSystem;

public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer spline;
    public float accelerateValue = 0.0001f;
    public float brakeValue = 0.0005f;
    public float speed;
    public float maxSpeed = 5;
    float distancePercentage = 0f;

    float splineLength;

    public bool isInRoadTrigger;
    public bool lawObeyed;

    private void Start()
    {
        splineLength = spline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)))
        {
            if (speed <= maxSpeed)
            speed = speed + accelerateValue;
        }
        else if ((Input.GetKey(KeyCode.S)) && (speed > 0))
        {
            speed = speed - brakeValue;
        }

        if (speed > 0)
        {
            var splinePos = spline.EvaluatePosition(distancePercentage);
    
            Vector2 currentPosition = new Vector2(splinePos.x, splinePos.y);
            transform.position = currentPosition;

            distancePercentage += speed * Time.deltaTime / splineLength;

            if (distancePercentage > 1f)
            {
                distancePercentage = 0f;
            }

            var nextSplinePos = spline.EvaluatePosition(distancePercentage + 0.001f);
            Vector2 nextPosition = new Vector2(nextSplinePos.x, nextSplinePos.y);
            
            Vector2 direction = nextPosition - currentPosition;

            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            speed = speed - brakeValue;
        }

        if ((Input.GetKey(KeyCode.S)) && (speed <= 0))
        {
            var splinePos = spline.EvaluatePosition(distancePercentage);
        
            Vector2 currentPosition = new Vector2(splinePos.x, splinePos.y);
            transform.position = currentPosition;

            distancePercentage -= brakeValue * Time.deltaTime / splineLength;

            if (distancePercentage < 0f)
            {
                distancePercentage = 1f;
            }

            var nextSplinePos = spline.EvaluatePosition(distancePercentage + 0.001f);
            Vector2 nextPosition = new Vector2(nextSplinePos.x, nextSplinePos.y);
            
            Vector2 direction = nextPosition - currentPosition;

            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }

        if ((speed < 0.5) && (isInRoadTrigger == true)) // if player speed = 0* while isInRoadTrigger = true, set lawObeyed to true
        {
            lawObeyed = true;
        }
    }

    public void OnStopSignTriggerEntered(GameObject hitObject) // check if player is in trigger box
    {
        Debug.Log("trigger entered");
        isInRoadTrigger = true;
    }
    private bool stopped = false;
    public void OnStopSignTriggerExited(GameObject hitObject) // if player leaves trigger box while isInRoadTrigger to true, do the following:
    {
        Debug.Log("trigger left");
        
        if (isInRoadTrigger == true)
        {
            if (lawObeyed == true) // if lawObeyed == true, set isInRoadTrigger to false
            {
                Debug.Log("law obeyed!");
                isInRoadTrigger = false;
                lawObeyed = false;
            }
            else if (lawObeyed == false) // if lawObeyed == false, end game
            {
                Debug.Log("law BROKEN!");
                stopped = true;
                //Losemanager.manager.Lose();
                Lose();
                isInRoadTrigger = false;
            }
        }
    }

    public void OnTrafficLightTriggerEntered(GameObject hitObject) // check if player is in trigger box
    {
        Debug.Log("trigger entered");
        isInRoadTrigger = true;
    }

    public void OnTrafficLightTriggerExited(GameObject hitObject) // check if player is in trigger box
    {
        Debug.Log("trigger entered");
        isInRoadTrigger = true;
    }

    public void Lose()
    {
        if (Losemanager.manager != null) 
        {
            Losemanager.manager.Lose();
        }
    }
    
}
