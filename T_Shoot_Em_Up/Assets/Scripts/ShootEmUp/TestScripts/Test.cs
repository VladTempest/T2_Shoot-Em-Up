using ShootEmUp.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class Test : MonoBehaviour
    {
        [FormerlySerializedAs("_spawner")]
        [SerializeField] private EnemySpawner _enemySpawner;

        void Start()
        {
            var _testSceneManager = SceneManager.Instance;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _enemySpawner.InstantiateEnemyRandomly();
            }
        }
    }
}
