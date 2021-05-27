using System.Collections;
using ShootEmUp.ObserverPattern;
using UnityEngine;

namespace ShootEmUp.Managers
{


    public class SceneManager : SingletonBase<SceneManager>,ISubscribers
    {
        private enum Scenes
        {
            MainMenu=0,GameplayScene=1
        }

        [SerializeField] private float _pauseBeforeLoadMainMenu=2f;
        [SerializeField] private float _pauseBeforeLoadGameplay=0.1f;
        
        private void Awake()
        {
            var sceneManager = SceneManager.Instance; //Initialize singleton pattern
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void LoadGameplayScene()
        {
            StartCoroutine(TimerForLoadScene(Scenes.GameplayScene,_pauseBeforeLoadGameplay)); //This is for scripts to get configs values for GameManager
        }

        private void LoadMainMenu()
        {
            StartCoroutine(TimerForLoadScene(Scenes.MainMenu,_pauseBeforeLoadMainMenu));
        }

        
        
        IEnumerator TimerForLoadScene(Scenes scene,float pauseBeforeLoad)
        {
            yield return new WaitForSeconds(pauseBeforeLoad);
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        }
        
        public void Subscribe()
        {
            EventBroker.PlayerDied += LoadMainMenu;
            EventBroker.PlayerWon += LoadMainMenu;

            EventBroker.PlayButtonClicked += LoadGameplayScene;
        }
        public void Unsubscribe()
        {
            EventBroker.PlayerDied -= LoadMainMenu;
            EventBroker.PlayerWon -= LoadMainMenu;
            
            EventBroker.PlayButtonClicked -= LoadGameplayScene;
        }
    }
    
    
}
