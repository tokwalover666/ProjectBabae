using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject settingsMenu, settingsText, howtoText;
    public void PlayGame()
    {
        SceneManager.LoadScene("Gamepllay");
        Time.timeScale = 1;
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void HowSettings()
    {
        settingsText.SetActive(false);
        howtoText.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void Close()
    {
        settingsMenu.SetActive(false);
    }
    public void Exit()
    {
        Debug.Log("Game exited");
        Application.Quit();
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
