using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Playgame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Application.Quit();
    }
}
