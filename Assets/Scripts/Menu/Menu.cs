using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameObject _menuWindow;

      //  [SerializeField] private Button _buttonResetLvl;
        

        public void OpenMenuWindow()
        {  
            _menuButton.SetActive(false);
            _menuWindow.SetActive(true);
        }

        public void CloseMenuWindow()
        {
            _menuButton.SetActive(true);
            _menuWindow.SetActive(false);
        }

        public void RestartLvl()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
