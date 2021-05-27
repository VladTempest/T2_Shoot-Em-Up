using System;
using ShootEmUp.GameConfigs;
using ShootEmUp.Managers;
using ShootEmUp.ObserverPattern;
using UnityEngine;
namespace ShootEmUp.Shooters
{
    public class PlayerShooter : Shooter,ISubscribers
    {
        private float _bulletDamagePlayer;
        private bool _isGameplayActive = true;
        private void Awake()
        {
            _bulletDamagePlayer = GameManager.Instance.configsDictionary[ConfigsEnum.Configs.PlayerDamage];
        }

        void Update()
        {
            if (Input.GetButton("Fire1")&&_isGameplayActive)
            {
                ShootIfEnoughTimePassedFromShot();
            }

        }

        void ChangeStateOfGame()
        {
            _isGameplayActive = false;
        }
        protected override float GetBulletDamage()
        {
            return _bulletDamagePlayer;
        }
        public void Subscribe()
        {
            EventBroker.PlayerDied += ChangeStateOfGame;
            EventBroker.PlayerWon += ChangeStateOfGame;
        }
        public void Unsubscribe()
        {
            EventBroker.PlayerDied -= ChangeStateOfGame;
            EventBroker.PlayerWon -= ChangeStateOfGame;
        }
    }
}
