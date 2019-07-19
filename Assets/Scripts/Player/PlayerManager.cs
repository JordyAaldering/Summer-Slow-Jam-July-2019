using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameObject go = other.gameObject;
        if (go.CompareTag("Spike") || go.CompareTag("Wall"))
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
