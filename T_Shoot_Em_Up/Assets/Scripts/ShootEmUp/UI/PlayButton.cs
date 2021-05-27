using ShootEmUp.ObserverPattern;
using UnityEngine;
using UnityEngine.UI;
namespace ShootEmUp.UI
{
    public class PlayButton : MonoBehaviour
    {
        void Awake()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallPlayButtonClicked);
        }
        void OnDestroy()
        {
            gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallPlayButtonClicked);
        
        }
    }
}
