using UnityEngine;

public class SetTriggetEveryNSecond : MonoBehaviour
{
    [SerializeField] private float Period = 7f;
    [SerializeField] private Animator Animator;
    
    private float _timer;
    [SerializeField] private string TriggerName = "Attack";

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > Period)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
