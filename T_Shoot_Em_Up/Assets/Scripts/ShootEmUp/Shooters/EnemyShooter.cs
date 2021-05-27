using ShootEmUp.EnemyAttacker;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.Shooters
{
    [RequireComponent(typeof(RangedEnemyAttacker))]
    public class EnemyShooter : Shooter
    {
        private float _bulletDamageEnemy=1f;
        public bool isInFireState = false;

        void Start()
        {
            _bulletDamageEnemy = GetComponent<RangedEnemyAttacker>().attackDamage;
        }
        void Update()
        {
            if (isInFireState)
            {
                ShootIfEnoughTimePassedFromShot();
            }

        }
        protected override float GetBulletDamage()
        {
            return _bulletDamageEnemy;
        }
    }
}
