#pragma warning disable 0649
using Abilities;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float forwardIncrease = 1.1f;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float jumpForce = 3f;

        [SerializeField] private float slideCooldown = 1f;
        private float slideCooldownCounter;

        [SerializeField] private Transform groundCheck;

        private bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.05f);
        private bool CanJump => IsGrounded && AbilityManager.instance.CanJump;

        private bool canDoubleJump;
        private bool CanDoubleJump => canDoubleJump && AbilityManager.instance.CanDoubleJump;

        private Rigidbody rb;
        private Animator anim;
        
        private static readonly int slide = Animator.StringToHash("Slide");

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
            forwardSpeed += forwardIncrease * Time.deltaTime;

            if (slideCooldownCounter > 0f)
            {
                slideCooldownCounter -= Time.deltaTime;
            }
        }

        public void Move(float amount)
        {
            transform.Translate(moveSpeed * Time.deltaTime * new Vector3(amount, 0f, 0f));
        }

        public void Jump()
        {
            if (CanJump)
            {
                canDoubleJump = true;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
            else if (CanDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
        }

        public void Slide()
        {
            if (slideCooldownCounter > 0f) return;
            
            slideCooldownCounter = slideCooldown;
            anim.SetTrigger(slide);
        }
    }
}
