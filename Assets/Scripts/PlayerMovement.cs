#pragma warning disable 0649
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 3f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 3f;

    [SerializeField] private Transform groundCheck;
    
    private bool IsGrounded => Physics.Raycast(groundCheck.position, Vector3.down, 0.1f);

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = rb.velocity.With(y: jumpForce);
        }
    }
}
