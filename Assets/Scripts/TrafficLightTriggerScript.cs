using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficLightTriggerScript : MonoBehaviour
{
    [Header("Settings")]
    public float minWait = 2f;
    public float maxWait = 5f;
    public float uiLingerTime = 2f;

    [Header("References")]
    public GameObject trafficLightSprite;
    public GameObject redLightSprite;
    public GameObject greenLightSprite;

    private bool isCoroutineRunning = false;
    private bool isRedLightActive = true;

    void Start()
    {
        if (trafficLightSprite != null) trafficLightSprite.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TrafficLight"))
        {
            if (!isCoroutineRunning)
            {
                Debug.Log("traffic light coroutine started!)");
                StartCoroutine(StartTrafficLight());
            }
        }

        if (other.CompareTag("TrafficLight2"))
        {
            if (isRedLightActive)
            {
                Debug.Log("LAW BROKEN!");
                // CALL LOSE SCRIPT
            }
        }
    }

    private IEnumerator StartTrafficLight()
    {
        isCoroutineRunning = true;
        
        if (trafficLightSprite != null) trafficLightSprite.SetActive(true);
        if (redLightSprite != null) redLightSprite.SetActive(true);
        if (greenLightSprite != null) greenLightSprite.SetActive(false);

        float waitTime = Random.Range(minWait, maxWait);
        Debug.Log("Red Light Active!");
        yield return new WaitForSeconds(waitTime);

        isRedLightActive = false;
        Debug.Log("Green Light Active!");
        if (redLightSprite != null) redLightSprite.SetActive(false);
        if (greenLightSprite != null) greenLightSprite.SetActive(true);

        yield return new WaitForSeconds(uiLingerTime);
        if (trafficLightSprite != null) trafficLightSprite.SetActive(false);
        
        isCoroutineRunning = false;
    }
}
