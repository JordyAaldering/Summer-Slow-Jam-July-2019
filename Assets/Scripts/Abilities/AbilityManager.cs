using UnityEngine;

namespace Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        public static AbilityManager instance { get; private set; }

        public AbilityUI abilityUI;
        
        private bool _canDoubleJump;
        public bool CanDoubleJump
        {
            get => _canDoubleJump;
            set
            {
                if (_canDoubleJump == value) return;
                
                _canDoubleJump = value;
                PlayerPrefs.SetInt("CanDoubleJump", value ? 1 : 0);
            }
        }

        private bool _canDuck;
        public bool CanDuck
        {
            get => _canDuck;
            set
            {
                if (_canDuck == value) return;
                
                _canDuck = value;
                PlayerPrefs.SetInt("CanDuck", value ? 1 : 0);
            }
        }

        private bool _canShoot;
        public bool CanShoot
        {
            get => _canShoot;
            set
            {
                if (_canShoot == value) return;
                
                _canShoot = value;
                PlayerPrefs.SetInt("CanShoot", value ? 1 : 0);
            }
        }


        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            
            _canDoubleJump = PlayerPrefs.GetInt("CanDoubleJump") == 1;
            _canDuck = PlayerPrefs.GetInt("CanDuck") == 1;
            _canShoot = PlayerPrefs.GetInt("CanShoot") == 1;
        }
    }
}
