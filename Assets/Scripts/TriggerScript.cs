using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private MoveAlongSpline playerCar; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoadTrigger"))
        {
            playerCar.OnTriggerEntered(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RoadTrigger"))
        {
            playerCar.OnTriggerExited(other.gameObject);
        }
    }
}
