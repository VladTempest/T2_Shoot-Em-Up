using System.Collections.Generic;
using ShootEmUp.GameConfigs;
using ShootEmUp.ObserverPattern;
using ShootEmUp.UI;
using UnityEngine;

namespace ShootEmUp.Managers
{
    public class GameManager : SingletonBase<GameManager>,ISubscribers
    {    
        private float CurrentHighscore
             {
                 get => _currentHighscore;
                 set
                 {
                     _currentHighscore = value;
                     highscoreUI.ChangeHighscore(_currentHighscore+"/"+maxScore);
                     if (_currentHighscore >= maxScore)
                     {
                         EventBroker.CallPlayerWon();
                     }
                 }
             }
        public Dictionary<ConfigsEnum.Configs,float> configsDictionary=new Dictionary<ConfigsEnum.Configs, float>();
        public HighscoreUI highscoreUI = null;
        public GameObject player;
        public float enemySpeed = 10f;
        public float maxScore = 100f;
        [SerializeField]
        private float _currentHighscore = 0f;
        [SerializeField]
        private float _scoreForEnemyKill = 10f;
   
        public void Awake()
       {
          var gameManager = GameManager.Instance; //Initialize singleton pattern
            Subscribe();
        }

        public void OnDestroy()
        {
            Unsubscribe();
        }
 

        private void AddScoreForEnemyKill()
        {
            CurrentHighscore += _scoreForEnemyKill;
        }
        void ResetCurrentHighscore()
        {
            CurrentHighscore = 0;
        }
        

        
        public void AssignConfigValues(SoloConfiguration[] configsArray )
        {
            foreach (SoloConfiguration soloConfig in configsArray)
            {
                if (configsDictionary.ContainsKey(soloConfig.typeOfConfig))
                {
                    configsDictionary[soloConfig.typeOfConfig] = soloConfig.CurrentValue;
                    return;
                }
                configsDictionary.Add(soloConfig.typeOfConfig, soloConfig.CurrentValue);
            }
        }
        
        
        public void Subscribe()
        {
            
            EventBroker.EnemyDied+=AddScoreForEnemyKill;
            EventBroker.PlayerDied += ResetCurrentHighscore;
            EventBroker.PlayerWon += ResetCurrentHighscore;
        }
        public void Unsubscribe()
        {
            EventBroker.EnemyDied-=AddScoreForEnemyKill;
            EventBroker.PlayerDied -= ResetCurrentHighscore;
            EventBroker.PlayerWon -= ResetCurrentHighscore;
        }
    }
}
