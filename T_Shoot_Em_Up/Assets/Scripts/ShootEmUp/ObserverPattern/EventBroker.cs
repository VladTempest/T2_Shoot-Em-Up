using System;

namespace ShootEmUp.ObserverPattern
{
    public static class EventBroker
    {
        #region Actions/Gameplay

       public static event Action EnemyDied;
       public static event Action PlayerDied;
       public static event Action PlayerWon;

        #endregion Actions/Gameplay
        
        #region Actions/MainMenu
        public static event Action PlayButtonClicked;
        #endregion Actions/MainMenu
        
        
        #region Calls/Gameplay

        
        public static void CallEnemyDied()
        {
            EnemyDied?.Invoke();
        }
        
        public static void CallPlayerDied()
        {
           PlayerDied?.Invoke();
        }
        
        public static void CallPlayerWon()
        {
            PlayerWon?.Invoke();
        }
        

        #endregion Calls/Gameplay
        
        #region Calls/MainMenu
        public static void CallPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }
        #endregion Calls/MainMenu
    }
}
