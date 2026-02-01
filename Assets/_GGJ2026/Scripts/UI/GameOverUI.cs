using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button restartButton;

    void Awake()
    {
        restartButton.onClick.AddListener(OnRestartHandler);
    }

    void OnRestartHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetText(string text)
    {
        scoreText.text = string.Format(scoreText.text, text);
    }
}
