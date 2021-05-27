namespace ShootEmUp.EnemyAttacker
{
    public class BomberEnemyAttacker : EnemyAttacker
    {
        protected override void Attack()
        {
            _playerCharacteristics.ReduceHealth(attackDamage);
            Destroy(gameObject);
        }

    }
}
