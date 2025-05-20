using UnityEngine;
using Zenject;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Inject] private IObjectPool<ExplosionRed> _explosionRedPool;
    [Inject] private IHealthSystem _playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            _playerHealth.TakeDamage(1);
            SpawnExplosion();
        }
    }

    private void SpawnExplosion()
    {
        ExplosionRed explosion = _explosionRedPool.GetObject();
        explosion.transform.position = transform.position;
    }
}