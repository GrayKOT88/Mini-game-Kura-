using UnityEngine;

public class ChickCollisionHandler : MonoBehaviour
{
    public event System.Action OnFoxCollision;
    public event System.Action OnCountCollision;

    private IObjectPool<Chick> _chickPool;
    private ExplosionSpawner _explosionSpawner;    

    public void Initialize(IObjectPool<Chick> chickPool, ExplosionSpawner explosionSpawner)
    {
        _chickPool = chickPool;
        _explosionSpawner = explosionSpawner;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            HandleFoxCollision();
        }
        else if (other.CompareTag("Count"))
        {
            HandleCountCollision();
        }
    }

    private void HandleFoxCollision()
    {
        _chickPool.ReturnObject(GetComponent<Chick>());        
        _explosionSpawner.SpawnExplosion();
        OnFoxCollision?.Invoke();
    }

    private void HandleCountCollision()
    {
        _chickPool.ReturnObject(GetComponent<Chick>());        
        OnCountCollision?.Invoke();
    }
}