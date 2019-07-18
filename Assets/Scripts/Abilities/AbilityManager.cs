using System;
using UnityEngine;

namespace Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        public static AbilityManager instance { get; private set; }
        
        public bool canDoubleJump;

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
        }
    }
}
