#pragma warning disable 0649
using UnityEngine;

namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        
        [SerializeField] private float cooldown = 1f;

        private void Update()
        {
            if (cooldown > 0f)
            {
                cooldown -= Time.deltaTime;
            }
        }

        public void Shoot()
        {
            if (cooldown > 0f) return;
            
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
