using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private float mouseDeadZone = 1f;
        [SerializeField] private float speedModifier = 1f;
        [SerializeField] private float speedClamp = 1f;
        
        private PlayerMovement movement;
        private PlayerCombat combat;
        private Transform player;
        private Camera cam;
        
        private void Start()
        {
            GameObject p = GameObject.FindWithTag("Player");

            movement = p.GetComponent<PlayerMovement>();
            combat = p.GetComponent<PlayerCombat>();
            
            player = p.transform;
            cam = Camera.main;
        }

        private void Update()
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            Vector3 playerPos = cam.WorldToScreenPoint(player.position);
            float diff = mousePos.x - playerPos.x;

            if (Mathf.Abs(diff) > mouseDeadZone)
            {
                movement.Move(Mathf.Clamp(diff / (mouseDeadZone * speedModifier), -speedClamp, speedClamp));
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                movement.Jump();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                movement.Slide();
            }
            
            if (Input.GetMouseButtonDown(2))
            {
                combat.Shoot();
            }
        }
    }
}
