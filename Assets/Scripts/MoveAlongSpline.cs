using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.InputSystem;

public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer spline;
    public float speed = 1f;
    float distancePercentage = 0f;

    float splineLength;

    public InputActionReference accelerate;

    private void OnEnable()
    {
        // 2. You must enable the action for it to work!
        accelerate.action.Enable();
    }

    private void OnDisable()
    {
        // 3. Clean up by disabling it when this object is gone
        accelerate.action.Disable();
    }

    private void Start()
    {
        splineLength = spline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        if (accelerate.action.IsPressed())
        {
            var splinePos = spline.EvaluatePosition(distancePercentage);
        
            Vector2 currentPosition = new Vector2(splinePos.x, splinePos.y);
            transform.position = currentPosition;

            distancePercentage += speed * Time.deltaTime / splineLength;

            if (distancePercentage > 1f)
            {
                distancePercentage = 0f;
            }

            var nextSplinePos = spline.EvaluatePosition(distancePercentage + 0.01f);
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
