#pragma warning disable 0649
using UnityEngine;

namespace Abilities
{
    public class AbilityPickup : MonoBehaviour
    {
        [SerializeField] private Ability ability;

        private void Start()
        {
            switch (ability)
            {
                case Ability.jump:
                    if (AbilityManager.instance.CanJump)
                    {
                        Destroy(gameObject);
                    }
                    break;
                
                case Ability.doubleJump:
                    if (AbilityManager.instance.CanDoubleJump)
                    {
                        Destroy(gameObject);
                    }
                    break;
                
                case Ability.slide:
                    if (AbilityManager.instance.CanSlide)
                    {
                        Destroy(gameObject);
                    }
                    break;
                
                case Ability.shoot:
                    if (AbilityManager.instance.CanShoot)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        public void Consume()
        {
            switch (ability)
            {
                case Ability.jump:
                    AbilityManager.instance.abilityUI.Enable("Jump", "LMB");
                    AbilityManager.instance.CanJump = true;
                    break;
                
                case Ability.doubleJump:
                    AbilityManager.instance.abilityUI.Enable("Double Jump", "LMB");
                    AbilityManager.instance.CanDoubleJump = true;
                    break;
                
                case Ability.slide:
                    AbilityManager.instance.abilityUI.Enable("Slide", "RMB");
                    AbilityManager.instance.CanSlide = true;
                    break;
                
                case Ability.shoot:
                    AbilityManager.instance.abilityUI.Enable("Shoot", "MMB");
                    AbilityManager.instance.CanShoot = true;
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
