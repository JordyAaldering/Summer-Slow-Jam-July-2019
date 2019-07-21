#pragma warning disable 0649
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public class AbilityUI : MonoBehaviour
    {
        [SerializeField] private GameObject abilityUnlockedPanel;
        [SerializeField] private Text abilityText;
        [SerializeField] private Text controlText;

        public void Enable(string name, string control)
        {
            Time.timeScale = 0f;
            abilityText.text = name.ToUpper();
            controlText.text = control.ToUpper();
            abilityUnlockedPanel.SetActive(true);
        }

        public void Disable()
        {
            abilityUnlockedPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
