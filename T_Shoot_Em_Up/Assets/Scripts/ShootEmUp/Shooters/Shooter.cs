using ShootEmUp.Characteristics;
using ShootEmUp.ObserverPattern;
using UnityEngine;
namespace ShootEmUp.Shooters
{
    public abstract class Shooter : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;
        [SerializeField]
        private GameObject _bullet;

        [SerializeField]
        private float _bulletForce=20f;

        [SerializeField]
        private double _timeBetweenShots = 0.5f;
        
        private float _fireTimer = 2f;
        



        protected abstract float GetBulletDamage();
        protected void ShootIfEnoughTimePassedFromShot()
        {
            _fireTimer += Time.deltaTime;
            if (_fireTimer >= _timeBetweenShots)
            {
                _fireTimer = 0;
                ShootBullet();
            }
        }
        private void ShootBullet()
        {
            GameObject bullet =Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.whoShot = GetComponent<CharacterCharacteristics>();
            bulletComponent.bulletDamage = GetBulletDamage();
            Rigidbody2D bulletRigidBody=bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);  
        }


        
    }
}
