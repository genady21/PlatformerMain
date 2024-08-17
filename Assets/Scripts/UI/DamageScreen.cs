using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour 
{
    [SerializeField] private Image _damageImage;
    
    private void OnEnable()
    {
        PlayerHealth.EventOnTakeDamage += StartEffect;
    }

    private void OnDisable()
    {
        PlayerHealth.EventOnTakeDamage -= StartEffect;
    }

    private void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        _damageImage.enabled = true;
        for (float t = 1; t > 0f; t-=Time.deltaTime)
        {
            _damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }
        _damageImage.enabled = false;
    }
}
