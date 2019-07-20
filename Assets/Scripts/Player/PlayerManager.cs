using Audio;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Transform player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (player.position.y < -10)
            {
                Die();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            GameObject go = other.gameObject;
            if (go.CompareTag("Wall") || go.CompareTag("WallGlass"))
            {
                Die();
            }
        }

        private static void Die()
        {
            AudioManager.instance.PlayEffect(AudioManager.instance.dieClip);
            
            FindObjectOfType<GameMenu>().GameOver();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Spike"))
            {
                Die();
            }
            else if (other.CompareTag("End"))
            {
                FindObjectOfType<GameMenu>().LevelComplete();
            }
        }
    }
}
