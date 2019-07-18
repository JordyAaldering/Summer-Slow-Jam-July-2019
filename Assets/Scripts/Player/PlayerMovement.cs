#pragma warning disable 0649
using Abilities;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float jumpForce = 3f;

        [SerializeField] private Transform groundCheck;

        private bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.05f);

        private bool canDoubleJump;
        private bool CanJump => canDoubleJump && AbilityManager.instance.CanDoubleJump;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
        }

        public void Move(float amount)
        {
            transform.Translate(moveSpeed * Time.deltaTime * new Vector3(amount, 0f, 0f));
        }

        public void Jump()
        {
            if (IsGrounded)
            {
                canDoubleJump = true;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
            else if (CanJump)
            {
                canDoubleJump = false;
                rb.velocity = rb.velocity.With(y: jumpForce);
            }
        }

        public void Duck()
        {
            // todo: duck
        }
    }
}
