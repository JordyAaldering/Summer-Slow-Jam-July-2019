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
                    AbilityManager.instance.CanDoubleJump = true;
                    break;
                case Ability.duck:
                    AbilityManager.instance.CanDuck = true;
                    break;
                case Ability.shoot:
                    AbilityManager.instance.CanShoot = true;
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
