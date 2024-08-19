using UnityEngine;

namespace Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameObject _menuWindow;

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
    }
}
