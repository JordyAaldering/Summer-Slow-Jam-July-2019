using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = speed * transform.forward;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject go = other.gameObject;
        if (go.CompareTag("Wall"))
        {
            Destroy(go);
            Destroy(gameObject);
        }
    }
}
