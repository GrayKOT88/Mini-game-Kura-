using UnityEngine;

public class ChickCollisionHandler : MonoBehaviour
{
    private IObjectPool<Chick> _chickPool;
    private ExplosionSpawner _explosionSpawner;
    private Counter _counter;

    public void Initialize(IObjectPool<Chick> chickPool, ExplosionSpawner explosionSpawner, Counter counter)
    {
        _chickPool = chickPool;
        _explosionSpawner = explosionSpawner;
        _counter = counter;
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
        _counter.AddEatenChicken();
        _explosionSpawner.SpawnExplosion();
    }

    private void HandleCountCollision()
    {
        _chickPool.ReturnObject(GetComponent<Chick>());
        _counter.AddSavedChicken();
    }
}