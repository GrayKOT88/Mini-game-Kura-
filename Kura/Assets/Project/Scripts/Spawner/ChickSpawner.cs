using System.Collections.Generic;
using UnityEngine;

public class ChickSpawner
{
    private IObjectPool<Chick> _chickPool;
    private List<Transform> _points;

    public ChickSpawner(IObjectPool<Chick> chickPool, List<Transform> points)
    {
        _chickPool = chickPool;
        _points = points;
    }

    public void SpawnChickWave(int numberOfChicks)
    {
        for (int i = 0; i < numberOfChicks; i++)
        {
            Chick chick = _chickPool.GetObject();
            chick.transform.position = _points[Random.Range(0, _points.Count)].position;
        }
    }
}