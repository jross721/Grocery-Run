using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Playgame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("SampleScene");
    }
    public void Credits()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.Quit();
    }
}
