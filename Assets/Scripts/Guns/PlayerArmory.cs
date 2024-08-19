using UnityEngine;

namespace Guns
{
    public class PlayerArmory : MonoBehaviour
    {
        [SerializeField] private Gun[] _guns;
        [SerializeField] private int _currentGunIndex;

        private void Start()
        {
            TakeGunByIndex(_currentGunIndex);
        }

        public void TakeGunByIndex(int gunindex)
        {
            _currentGunIndex = gunindex;
            
            for (int i = 0; i < _guns.Length; i++)
            {
                if (i == gunindex)
                {
                   _guns[i].Activate();
                }
                else
                {
                    _guns[i].Deactivate();
                }
            }
        }

        public void AddBullets(int gunIndex, int numberOfBullest)
        {
            _guns[gunIndex].AddBullets(numberOfBullest);
        }
    }
    
}
