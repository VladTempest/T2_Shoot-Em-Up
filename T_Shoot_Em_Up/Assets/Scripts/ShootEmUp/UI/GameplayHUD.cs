using ShootEmUp.ObserverPattern;
using UnityEngine;
namespace ShootEmUp.UI
{
    public class GameplayHUD : ShownHidinUIBase
    {
        
        public override void Subscribe()
        {
            EventBroker.PlayerDied+=HideThisUIObject;
            EventBroker.PlayerWon+=HideThisUIObject;
        }
        public override void Unsubscribe()
        {
            EventBroker.PlayerDied-=HideThisUIObject;
            EventBroker.PlayerWon-=HideThisUIObject;
        }
    }
}
