using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.InputSystem;

public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer spline;
    public float accelerateValue = 0.01f;
    public float brakeValue = 0.005f;
    public float speed;
    float distancePercentage = 0f;

    float splineLength;

    private void Start()
    {
        splineLength = spline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)))
        {
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
    }
}
