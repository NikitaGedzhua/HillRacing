using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   [SerializeField] private Button startButton;
   [SerializeField] private Button quitButton;

   private void Awake()
   {
      startButton.onClick.AddListener(StartGame);
      quitButton.onClick.AddListener(QuitGame);
   }

   private void StartGame()
   {
      LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }

   private void QuitGame()
   {
      Application.Quit();
   }

   private void LoadScene(int buildIndex)
   {
      SceneManager.LoadScene(buildIndex);
   }
}
