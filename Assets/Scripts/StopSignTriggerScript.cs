using UnityEngine;

public class StopSignTriggerScript : MonoBehaviour
{
    [SerializeField] private MoveAlongSpline playerCar; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StopSign"))
        {
            playerCar.OnStopSignTriggerEntered(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StopSign"))
        {
            playerCar.OnStopSignTriggerExited(other.gameObject);
        }
    }
}
