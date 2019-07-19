#pragma warning disable 0649
using UnityEngine;

namespace Abilities
{
    public class AbilityPickup : MonoBehaviour
    {
        [SerializeField] private Ability ability;

        public void Consume()
        {
            switch (ability)
            {
                case Ability.doubleJump:
                    AbilityManager.instance.abilityUI.Enable("Double Jump", "LMB");
                    AbilityManager.instance.CanDoubleJump = true;
                    break;
                case Ability.slide:
                    AbilityManager.instance.abilityUI.Enable("Slide", "RMB");
                    AbilityManager.instance.CanDuck = true;
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
