#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{

    public class StartGameMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;
       
        [SerializeField] private SoundManager _soundManager;




        private void Start()
        {
            _startButton.onClick.AddListener(CloseMenuWindow);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(CloseMenuWindow);
            _exitButton.onClick.RemoveListener(ExitGame);
        }
        
        public void CloseMenuWindow()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
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
