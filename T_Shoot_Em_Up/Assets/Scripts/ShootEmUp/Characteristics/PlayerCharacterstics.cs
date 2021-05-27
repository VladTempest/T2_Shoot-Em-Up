using ShootEmUp.GameConfigs;
using ShootEmUp.Managers;
using ShootEmUp.ObserverPattern;
using UnityEngine;

namespace ShootEmUp.Characteristics
{
    public class PlayerCharacterstics : CharacterCharacteristics
    {
        [SerializeField]
        private GameObject _playerVisuals=null;
        
        public override void Awake()
        {
            base.Awake();
            _maxHealth = GameManager.Instance.configsDictionary[ConfigsEnum.Configs.PlayerHealth];
        }
        protected override void DestroyCharacter()
        {
            if (_playerVisuals.activeSelf)
            {
                _playerVisuals.SetActive(false);
                EventBroker.CallPlayerDied();
            }
        }

        
    }
}
