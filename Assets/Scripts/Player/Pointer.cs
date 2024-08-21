using UnityEngine;

namespace Player
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private Transform _aim;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Transform Body;

        [SerializeField] private float yEuler = 45f;

        private float _yEuler;

        private void LateUpdate()
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(-Vector3.forward, Vector3.zero);
            float distance;

            plane.Raycast(ray, out distance);
            Vector3 point = ray.GetPoint(distance);
            _aim.position = point;

            Vector3 toAim = _aim.position - transform.position;
            transform.rotation = Quaternion.LookRotation(toAim);

            if (toAim.x < 0)
            {
                yEuler = Mathf.Lerp(yEuler, 45f, Time.deltaTime * 15f);
            }
            else
            {
                yEuler = Mathf.Lerp(yEuler, -45f, Time.deltaTime * 15f);
            }
            
            Body.localEulerAngles = new Vector3(0, yEuler, 0);
        }
    }
}