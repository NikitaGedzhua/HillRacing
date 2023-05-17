using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button backToMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void RestartGame()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackToMenu()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
