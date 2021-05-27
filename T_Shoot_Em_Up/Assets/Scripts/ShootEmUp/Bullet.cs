using ShootEmUp.Characteristics;
using UnityEngine;
namespace ShootEmUp
{
    public class Bullet : MonoBehaviour
    {
        public CharacterCharacteristics whoShot=null;
        public float bulletDamage;
    
        private void OnCollisionEnter2D()
        {
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
