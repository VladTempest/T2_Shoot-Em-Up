using ShootEmUp.Managers;
using UnityEngine;

namespace ShootEmUp
{[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController :MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private Vector2 _mousePosition;
 
        void Awake()
        {
        _camera=Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        GameManager.Instance.player = gameObject;
        }
        
        void Update()
        {
            _mousePosition=_camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            FaceMousePointer();   
        }

        private void FaceMousePointer()
        {
            Vector2 lookDirection = _mousePosition - _rigidbody2D.position;
            float angleForPlayerRotation = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg-90f;
            _rigidbody2D.rotation = angleForPlayerRotation;
            
        } 
    }
}
