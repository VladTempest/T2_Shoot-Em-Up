using System.Collections;
using UnityEngine;

namespace ShootEmUp.EnemyAttacker
{
    public class MeleeEnemyAttacker : EnemyAttacker
    {
        [SerializeField]
        private float _pauseBetweenAttacks = 1f;
        private Coroutine _attackingCoroutine = null;
        protected override void Attack()
        {
            _attackingCoroutine = StartCoroutine(AttackingCycle());
        }
        public void OnDestroy()
        {
            if (_attackingCoroutine != null)
            {
                StopCoroutine(_attackingCoroutine);
            }
        }
        IEnumerator AttackingCycle()
        {
            while (true)
            {
                _playerCharacteristics.ReduceHealth(attackDamage);
                yield return new WaitForSeconds(_pauseBetweenAttacks);
            }
        }
    }
}
