using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public string sceneToLoad = "lv";

    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }
        
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
