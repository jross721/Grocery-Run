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
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Lose()
    
    {
        if (isGameOver) return;

        isGameOver = true;
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        isGameOver = false;

        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
    }
    public void ReplayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isGameOver = false;
        Application.Quit();
    }
}
