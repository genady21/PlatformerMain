using System;
using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
   // [SerializeField] private PlayerHealth _playerHealth;
  

    private void OnEnable()
    {
        PlayerHealth.EventOnTakeDamage += StartBlink;
       // EnemyHealh.EventOnTakeDamage += StartBlink;
    }

    private void OnDisable()
    {
        PlayerHealth.EventOnTakeDamage -= StartBlink;
      //  EnemyHealh.EventOnTakeDamage -= StartBlink;
    }

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t+=Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                 _renderers[i].material.SetColor("_EmissionColor", new Color(Mathf.Sin(t*30f)*0.5f+0.5f,0,0,0));
            }
            yield return null;
        }
    }
}
