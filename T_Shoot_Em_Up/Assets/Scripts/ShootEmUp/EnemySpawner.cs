
using System;
using System.Collections;
using ShootEmUp.GameConfigs;
using ShootEmUp.Managers;
using ShootEmUp.ObserverPattern;
using ShootEmUp.Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour,ISubscribers
    {
        [SerializeField] private EnemiesListSettings _enemiesListSettings = null;
        [SerializeField] private float _spawnRadius = 6f;
        [SerializeField] private float _spawnRate =1.2f;

        [SerializeField] private Coroutine _spawnCoroutine=null;
        private void Awake()
        {
            _spawnRate = GameManager.Instance.configsDictionary[ConfigsEnum.Configs.EnemiesSpawnRate];
            _spawnCoroutine= StartCoroutine(SpawnEnemies());
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        public void InstantiateEnemyRandomly()
        {
            int listLength = _enemiesListSettings.list.Count ;
            Instantiate(_enemiesListSettings.list[Random.Range(0, listLength)], RandomCircle(transform.position, _spawnRadius), transform.rotation);
        }

        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                InstantiateEnemyRandomly();
            }
            
        }

        void StopSpawnin()
        {
            StopCoroutine(_spawnCoroutine);
        }

        

        private Vector2 RandomCircle(Vector2 center, float radius)
        {
            float ang = Random.value * 360;
            Vector2 position;
            position.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            position.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            return position;
        }
        public void Subscribe()
        {
            EventBroker.PlayerDied += StopSpawnin;
            EventBroker.PlayerWon += StopSpawnin;
        }
        public void Unsubscribe()
        {
            EventBroker.PlayerDied -= StopSpawnin;
            EventBroker.PlayerWon -= StopSpawnin;
        }
    }
}
