using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public Button mainMenuBtn;
    public Button retryBtn;
    public Button quitBtn;

    void Start()
    {
        mainMenuBtn.onClick.AddListener(OnMainMenuClicked);
        retryBtn.onClick.AddListener(OnRetryClicked);
        quitBtn.onClick.AddListener(OnQuitClicked);
    }

    void OnMainMenuClicked()
    {
        SceneManager.LoadScene("main");
    }

    void OnRetryClicked()
    {
        SceneManager.LoadScene("lv");
    }

    void OnQuitClicked()
    {
        Application.Quit();
    }
}
