#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private GameObject _gameOverMenu;
        
        private void Start()
        {
            _startButton.onClick.AddListener(RestartLvl);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(RestartLvl);
            _exitButton.onClick.RemoveListener(ExitGame);
        }
        public void RestartLvl()
        {
            SceneManager.LoadScene(1);
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
