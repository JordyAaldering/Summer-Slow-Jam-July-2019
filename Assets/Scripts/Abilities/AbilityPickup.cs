#pragma warning disable 0649
using System;
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
                    AbilityManager.instance.canDoubleJump = true;
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
