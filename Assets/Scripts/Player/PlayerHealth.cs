using UnityEngine;
using UnityEngine.Events;

   public class PlayerHealth : MonoBehaviour
   {
      [SerializeField] private int _health = 5;
      [SerializeField] private int _maxHealth = 10;

      [SerializeField] private HealthUI _healthUI;
      [SerializeField] private GameObject _gameOverMenu;
      
      [SerializeField] private AudioSource _takeDmgSound;
      [SerializeField] private AudioSource _addHealthSound;
      
      private bool _invulnerble = false;

      public static UnityAction EventOnTakeDamage;

      private void Start()
      {
         _healthUI.Setup(_maxHealth);
         _healthUI.DisplayHealth(_health);
      }

      public void TakeDamage(int damageValue)
      {
         if (_invulnerble == false)
         {
            _health -= damageValue;
            if (_health <= 0)
            {
               _health = 0;
               Die();
            }

            _invulnerble = true;
            Invoke("StopInvulnerable", 1f);
            _healthUI.DisplayHealth(_health);
            _takeDmgSound.Play();

            EventOnTakeDamage?.Invoke();
         }
      }

      private void StopInvulnerable()
      {
         _invulnerble = false;
      }

      public void AddHealth(int healthValue)
      {
         _health += healthValue;
         if (_health > _maxHealth)
         {
            _health = _maxHealth;
         }

         _healthUI.DisplayHealth(_health);
         _addHealthSound.Play();
      }

      private void Die()
      {
         Time.timeScale = 0f;
         _gameOverMenu.SetActive(true);
      }
   }

