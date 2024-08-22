#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuWindow; 
        [SerializeField] private GameObject _startMenuWindow; 
        
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _againButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        
        [SerializeField] private Toggle _toggleSound;
        [SerializeField] private Slider _sliderSound;
        [SerializeField] private SoundManager _soundManager;

        private void Awake()
        {
            Time.timeScale = 1f;
        }

        private void Start()
      {
          
          _againButton.onClick.AddListener(RestartLvl);
          _continueButton.onClick.AddListener(CloseMenuWindow);
          _menuButton.onClick.AddListener(OpenMenuWindow);
          _toggleSound.onValueChanged.AddListener(_soundManager.SetMusicEnabled);
          _sliderSound.onValueChanged.AddListener(_soundManager.SetValume);
          _exitButton.onClick.AddListener(ExitGame);
      }

      private void OnDestroy()
      {
          _againButton.onClick.RemoveListener(RestartLvl);
          _menuButton.onClick.RemoveListener(OpenMenuWindow);
          _continueButton.onClick.RemoveListener(CloseMenuWindow);
          _toggleSound.onValueChanged.RemoveListener(_soundManager.SetMusicEnabled);
          _sliderSound.onValueChanged.RemoveListener(_soundManager.SetValume);
          _exitButton.onClick.RemoveListener(ExitGame);
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
            SceneManager.LoadScene(1);
            _startMenuWindow.SetActive(false);
        }
        public void ExitGame()
        {
#if UNITY_EDITOR
           
            EditorApplication.isPlaying = false;
#else
            
            Application.Quit();
#endif
        }
    }
}
