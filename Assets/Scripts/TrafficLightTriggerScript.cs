using UnityEngine;

public class TrafficLightTriggerScript : MonoBehaviour
{
    [SerializeField] private MoveAlongSpline playerCar; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TrafficLight"))
        {
            playerCar.OnTrafficLightTriggerEntered(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TrafficLight"))
        {
            playerCar.OnTrafficLightTriggerExited(other.gameObject);
        }
    }

    // when player enters range of light, pick random number from range
    // start timer
    // when timer raches random number, set isGreenLight to true
    
    // if player leaves range of light
}
