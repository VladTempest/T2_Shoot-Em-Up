using ShootEmUp.GameConfigs;
using ShootEmUp.Managers;
using ShootEmUp.ObserverPattern;
using UnityEngine;

namespace ShootEmUp.Characteristics
{
    public class EnemyCharacteristics : CharacterCharacteristics, ISubscribers
    {
        public override void Awake()
        {
            base.Awake();
            _maxHealth = GameManager.Instance.configsDictionary[ConfigsEnum.Configs.EnemiesHealth] * _maxHealthPointsCoefficient;
        }
        void OnEnable()
        {
            Subscribe();
        }
        private void OnDestroy()
        {
            Unsubscribe();
        }
        protected override void DestroyCharacter()
        {
            EventBroker.CallEnemyDied();
            Destroy(gameObject);
        }
        public override void OnCollisionEnter2D(Collision2D other)
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            if (ChekIfBulletShotByPlayer(bullet))
            {
                ReduceHealth(bullet.bulletDamage);
            }
        }
        private bool ChekIfBulletShotByPlayer(Bullet bullet)
        {
            return bullet != null && (bullet.whoShot.GetComponent<PlayerController>() != null);
        }
        void HideAfterEndGame()
        {
            gameObject.SetActive(false);
        }
        public void Subscribe()
        {
            EventBroker.PlayerWon += HideAfterEndGame;
            EventBroker.PlayerDied += HideAfterEndGame;
        }
        public void Unsubscribe()
        {
            EventBroker.PlayerWon -= HideAfterEndGame;
            EventBroker.PlayerDied -= HideAfterEndGame;
        }
    }
}
