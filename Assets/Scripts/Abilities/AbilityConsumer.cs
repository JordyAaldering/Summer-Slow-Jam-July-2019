using UnityEngine;

namespace Abilities
{
    public class AbilityConsumer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<AbilityPickup>()?.Consume();
        }
    }
}
