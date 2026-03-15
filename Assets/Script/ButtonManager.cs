using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject settingsMenu, maingridMenu,
        settingsText, howtoText;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Gamepllay");
        Time.timeScale = 1;
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        maingridMenu.SetActive(false);
        settingsText.SetActive(true);
        howtoText.SetActive(false);
        Time.timeScale = 0;
    }
    public void HowSettings()
    {
        Debug.Log("How settings displayed");
        settingsText.SetActive(false);
        howtoText.SetActive(true);
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        Debug.Log("Resumed");
        settingsMenu.SetActive(false);
        maingridMenu.SetActive(true);
        Time.timeScale = 1;

    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);

        Time.timeScale = 1;
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
