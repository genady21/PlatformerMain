using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuWindow;
        
        [SerializeField] private Button _againButton;
        [SerializeField] private Button _continueButton;
        
      private void Start()
      {
          _againButton.onClick.AddListener(RestartLvl);
          _continueButton.onClick.AddListener(CloseMenuWindow);
          _menuButton.onClick.AddListener(OpenMenuWindow);
      }

      private void OnDestroy()
      {
          _againButton.onClick.RemoveListener(RestartLvl);
          _menuButton.onClick.RemoveListener(OpenMenuWindow);
          _continueButton.onClick.RemoveListener(CloseMenuWindow);
      }

      public void OpenMenuWindow()
        {  
            _menuButton.gameObject.SetActive(false);
            _menuWindow.SetActive(true);
            Time.timeScale = 0f;

        }

        public void CloseMenuWindow()
        {
            _menuButton.gameObject.SetActive(true);
            _menuWindow.SetActive(false);
            Time.timeScale = 1f;
        }

        public void RestartLvl()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }
}
