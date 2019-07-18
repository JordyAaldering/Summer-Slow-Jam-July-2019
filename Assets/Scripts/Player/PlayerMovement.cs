﻿#pragma warning disable 0649
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 3f;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float jumpForce = 3f;

        [SerializeField] private Transform groundCheck;

        private bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.05f);

        private bool canDoubleJump;
        private bool doubleJumpUnlocked = true; // temporarily set to true
        private bool CanDoubleJump => canDoubleJump && doubleJumpUnlocked;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded)
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
        }
    }
}
