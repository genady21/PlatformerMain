using UnityEngine;

namespace Player
{
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _teleportDestination;
        
        [SerializeField] private GameObject _playerParent;
        
        [SerializeField] private GameObject _platformOld;
        [SerializeField] private GameObject _platformNew;
        
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private GameObject _cameraParent;


        private void Start()
        {
            _platformNew.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.IsChildOf(_playerParent.transform))
            {
                var playerStatus = _playerParent.GetComponent<PlayerHealth>();

                if (playerStatus != null)
                {
                    _playerParent.transform.position = _teleportDestination.position;

                    _playerCamera.transform.SetParent(_cameraParent.transform);
                    _playerCamera.transform.localPosition = Vector3.zero;
                    _playerCamera.transform.localRotation = Quaternion.identity;
                    
                    _platformOld.SetActive(false);
                    _platformNew.SetActive(true);
                }
            }
        }
    }
}