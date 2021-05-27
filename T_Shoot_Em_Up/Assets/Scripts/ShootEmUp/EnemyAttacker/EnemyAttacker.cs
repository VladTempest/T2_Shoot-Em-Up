using ShootEmUp.Characteristics;
using ShootEmUp.GameConfigs;
using ShootEmUp.Managers;
using ShootEmUp.TriggerCircles;
using UnityEngine;

namespace ShootEmUp.EnemyAttacker
{
    public abstract class EnemyAttacker : MonoBehaviour
    {
        protected internal float attackDamage = 1f;
        protected PlayerCharacterstics _playerCharacteristics;
        [SerializeField]
        protected float _attackDamageCoefficient = 1f;
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private Triggers.CircleTriggers _triggerToStartAttacking;
        

        protected abstract void Attack();
        protected void Awake()
        {
            attackDamage = GameManager.Instance.configsDictionary[ConfigsEnum.Configs.EnemiesDamage] * _attackDamageCoefficient;
            
            _player = GameManager.Instance.player;
            _playerCharacteristics = _player.GetComponent<PlayerCharacterstics>();
        }
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<TriggerCircle>() != null)
                if (other.GetComponent<TriggerCircle>().typeOfTrigger == _triggerToStartAttacking)
                    Attack();
        }
    }
}
