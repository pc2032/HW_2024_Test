using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private player1 playerScript;

    void Start()
    {
        playerScript = FindObjectOfType<player1>();
    }

    void Update()
    {
        if (playerScript != null && scoreText != null)
        {
            scoreText.text = "SCORE: " + playerScript.score;
        }
    }
}
