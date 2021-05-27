using ShootEmUp.Shooters;
using UnityEngine;
namespace ShootEmUp.EnemyAttacker
{
    [RequireComponent(typeof(EnemyShooter))]
    public class RangedEnemyAttacker : EnemyAttacker
    {
        private EnemyShooter _shooter;
        public void Start()
        {
            _shooter = GetComponent<EnemyShooter>();
        }

        protected override void Attack()
        {
            _shooter.isInFireState = true;
        }

    }
}
