using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private const float MAX_SPEED_ANGLE = -120;
    private const float ZERO_SPEED_ANGLE = 210;

    [SerializeField] private Transform needleTransform;
    private float speedMax;
    private float speed;
    private void Awake()
    {
        speed = 0f;
        speedMax = 120f;
    }
    private void Update()
    {
        HandlePlayerInput();
        if (speed > speedMax) speed = speedMax;
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());

    }
    private void HandlePlayerInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            float acceleration = 50f;
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            float brakeSpeed = 100f;
            speed -= brakeSpeed * Time.deltaTime;
        }
    }
    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = speed / speedMax;
        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;

    }

}
