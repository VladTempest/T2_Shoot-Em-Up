using ShootEmUp.Managers;
using ShootEmUp.TriggerCircles;
using UnityEngine;


namespace ShootEmUp
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMover : MonoBehaviour
    {
        private float _enemySpeed = 1f;
        private Rigidbody2D _enemyRigidbody = null;
        [SerializeField]
        private float _enemySpeedCoefficient = 1f;
        [SerializeField]
        private Transform _playerTransform = null;
        [SerializeField]
        private Triggers.CircleTriggers _typeOfCircleTriggerToStop;
        [SerializeField]
        private GameObject _player;
        void Awake()
        {
            _enemySpeed = GameManager.Instance.enemySpeed * _enemySpeedCoefficient;
            
            _player = GameManager.Instance.player;
            _enemyRigidbody = GetComponent<Rigidbody2D>();
            _playerTransform = _player.GetComponent<Transform>();
            FacePlayer();
            MoveCharacter();

        }
        void MoveCharacter()
        {
            _enemyRigidbody.velocity=((_playerTransform.position - transform.position) * _enemySpeed*0.1f);  
        }

        void StopCharacter()
        {
            _enemyRigidbody.velocity = new Vector2(0, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<TriggerCircle>() != null)
            {
                if (other.GetComponent<TriggerCircle>().typeOfTrigger == _typeOfCircleTriggerToStop)
                {
                    StopCharacter();
                }
            }
        
        }

        private void FacePlayer()
        {
            Vector2 lookDirection = _playerTransform.position - transform.position;
            float angleForEnemyRotation = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg-90f;
            _enemyRigidbody.rotation =angleForEnemyRotation;
        }



        
    }
}
