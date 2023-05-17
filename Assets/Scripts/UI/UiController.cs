using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private CarLogic carlogic;
    [SerializeField] private MoveButton[] controllButtons;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_Text coinText;

    private void Awake()
    {
        backButton.onClick.AddListener(BackToMenu);
        InitUI();
    }
    
    private void OnEnable()
    {
        coinText.text = "0";
        
        this.Subscribe(eEventType.GroundTouched, (o) => ShowDeadScreen());
        this.Subscribe(eEventType.CoinPicked, (o) => UpdateCoinScore((int) o));
    }

    private void OnDisable()
    {
        this.Unsubscribe(eEventType.GroundTouched, (o) => ShowDeadScreen());
        this.Unsubscribe(eEventType.CoinPicked, o => UpdateCoinScore((int) o));
    }

    private void UpdateCoinScore(int value)
    {
        var current = int.Parse(coinText.text);
        coinText.text = (current + value).ToString();
    }

    private void ShowDeadScreen()
    {
        gameOverUI.gameObject.SetActive(true);
    }

    private void InitUI()
    {
        foreach (var button in controllButtons)
        {
            button.Init(carlogic);
        }
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
