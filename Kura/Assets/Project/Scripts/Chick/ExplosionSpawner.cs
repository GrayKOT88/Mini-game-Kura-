using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    private ExplosionRedPool _explosionRedPool;
    public void Initialize(ExplosionRedPool explosionRedPool)
    {        
        _explosionRedPool = explosionRedPool;        
    }

    public void SpawnExplosion()
    {
        ExplosionRed explosionRed = _explosionRedPool.GetObject();
        explosionRed.transform.position = transform.position;
    }
}