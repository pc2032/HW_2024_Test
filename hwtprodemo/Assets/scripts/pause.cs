using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeBtn;
    public Button menuBtn;
    public Button quitBtn;

    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);

        resumeBtn.onClick.AddListener(OnResumeClicked);
        menuBtn.onClick.AddListener(OnMenuClicked);
        quitBtn.onClick.AddListener(OnQuitClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void OnResumeClicked()
    {
        Resume();
    }

    void OnMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }

    void OnQuitClicked()
    {
        Application.Quit();
    }
}
