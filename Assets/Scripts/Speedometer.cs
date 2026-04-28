using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -120;
    private const float ZERO_SPEED_ANGLE = 210;

    [SerializeField] private Transform needleTransform;
    [SerializeField] private MoveAlongSpline splineMovement;
    [SerializeField] private float speedMax = 100f;
    [SerializeField] private float rotationOffset = 0f;
    
    private void Update()
    {
        if (splineMovement != null && needleTransform != null)
        {
            float currentSpeed = splineMovement.speed;
            float targetRotation = GetSpeedRotation(currentSpeed) + rotationOffset;
            needleTransform.eulerAngles = new Vector3(0, 0, targetRotation);
        }
    }

    private float GetSpeedRotation(float currentSpeed)
    {
        float clampedSpeed = Mathf.Clamp(currentSpeed, 0f, speedMax);
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = clampedSpeed / speedMax;
        return ZERO_SPEED_ANGLE - (speedNormalized * totalAngleSize);
    }

}
