using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private ExplosionRedPool explosionRedPool;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            playerHealth.TakeDamage(1);
            SpawnExplosion();
        }
    }

    private void SpawnExplosion()
    {
        ExplosionRed explosion = explosionRedPool.GetObject();
        explosion.transform.position = transform.position;
    }
}