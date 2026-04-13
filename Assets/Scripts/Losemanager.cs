using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Losemanager : MonoBehaviour
{
    public static Losemanager manager;
    public static bool isGameOver;

    [SerializeField] private GameObject loseScreen;
    private void Awake()
    {
        manager = this;
        isGameOver = false;
        loseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Lose()
    
    {
        if (isGameOver) return;

        isGameOver = true;
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
