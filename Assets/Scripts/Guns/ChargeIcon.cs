using UnityEngine;
using UnityEngine.UI;

namespace Guns
{
    public class ChargeIcon : MonoBehaviour
    {
        [SerializeField] private Image _backGround;
        [SerializeField] private Image _foreGround;
        [SerializeField] private Text _text;

        public void StartCharge()
        {
            _backGround.color = new Color(1f, 1f, 1f, 0.2f);
            _foreGround.enabled = true;
            _text.enabled = true;
        }

        public void StopCharge()
        {
            _backGround.color = new Color(1f, 1f, 1f, 1f);
            _foreGround.enabled = false;
            _text.enabled = false;
        }

        public void SetChargeValue(float currentCharge, float maxCharge)
        {
            _foreGround.fillAmount = currentCharge / maxCharge;
            _text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
        }
    }
}

