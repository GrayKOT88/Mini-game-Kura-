using System.Collections.Generic;
using UnityEngine;

public class ChickSpawner
{
    private IObjectPool<Chick> _chickPool;
    private List<Transform> _points;
    private Transform _player;
    private IObjectPool<ExplosionRed> _explosionRedPool;
    private Counter _counter;

    public ChickSpawner(IObjectPool<Chick> chickPool, List<Transform> points, Transform player,
        IObjectPool<ExplosionRed> explosionRedPool, Counter counter)
    {
        _chickPool = chickPool;
        _points = points;
        _player = player;
        _explosionRedPool = explosionRedPool;
        _counter = counter;
    }

    public void SpawnChickWave(int numberOfChicks)
    {
        for (int i = 0; i < numberOfChicks; i++)
        {
            Chick chick = _chickPool.GetObject();
            chick.Initialize(_chickPool, _player, _explosionRedPool, _counter);
            chick.transform.position = _points[Random.Range(0, _points.Count)].position;
        }
    }
}