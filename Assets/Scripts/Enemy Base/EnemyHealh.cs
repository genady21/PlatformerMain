using UnityEngine;
using UnityEngine.Events;

public class EnemyHealh : MonoBehaviour
{
    [SerializeField] private int _healh = 1;
    public static UnityAction EventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _healh -= damageValue;
        if (_healh <= 0) Die();
        
        EventOnTakeDamage?.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}