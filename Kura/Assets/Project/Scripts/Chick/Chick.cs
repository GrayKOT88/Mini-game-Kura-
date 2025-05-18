using UnityEngine;

public class Chick : MonoBehaviour
{
    private ChickCollisionHandler _collisionHandler;
    private ChickMovement _movement;
    private ExplosionSpawner _explosionSpawner;
    public ChickCollisionHandler CollisionHandler => _collisionHandler;

    private void Awake()
    {
        _collisionHandler = GetComponent<ChickCollisionHandler>();
        _movement = GetComponent<ChickMovement>();
        _explosionSpawner = GetComponent<ExplosionSpawner>();
    }

    public void Initialize(IObjectPool<Chick> chickPool, Transform player,
        IObjectPool<ExplosionRed> explosionRedPool)
    {
        _movement.Initialize(player);
        _collisionHandler.Initialize(chickPool, _explosionSpawner);
        _explosionSpawner.Initialize(explosionRedPool);
    }    
}
