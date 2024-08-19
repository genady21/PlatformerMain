using UnityEngine;

namespace Menu
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        
        public void SetMusicEnabled(bool value)
        {
            _music.enabled = value;
        }

        public void SetValume(float value)
        {
            AudioListener.volume = value;
        }
    }
}
