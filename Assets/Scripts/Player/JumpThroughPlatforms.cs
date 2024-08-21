using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class JumpThroughPlatforms : MonoBehaviour
    {
        public float disableTime = 0.3f; // Время, на которое отключается коллизия

        [SerializeField] private Collider playerCollider;

        private void Start()
        {
            // Получаем коллайдер персонажа
            playerCollider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Если нажата клавиша прыжка
            {
                // Выполняем проверку под персонажем
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Untagged")) // Проверяем, что это платформа
                    {
                        // Отключаем коллизию с платформой временно
                        StartCoroutine(DisableCollisionTemporarily(hit.collider));
                    }
                }
            }
        }

        private IEnumerator DisableCollisionTemporarily(Collider platformCollider)
        {
            // Отключаем коллизию между персонажем и платформой
            Physics.IgnoreCollision(playerCollider, platformCollider, true);
            yield return new WaitForSeconds(disableTime);
            // Включаем коллизию снова
            Physics.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }
}

