using System.Collections.Generic;
using UnityEngine;

public class FoxSpawner
{
    private IObjectPool<Fox> _foxPool;
    private List<Transform> _points;

    public FoxSpawner(IObjectPool<Fox> foxPool, List<Transform> points)
    {
        _foxPool = foxPool;
        _points = points;
    }

    public void SpawnFoxWave()
    {
        SpawnFox();
        if (Progress.PlayerData.saveChick >= 50)
        {
            SpawnFox();
        }
        if (Progress.PlayerData.saveChick >= 100)
        {
            SpawnFox();
        }
    }

    private void SpawnFox()
    {
        Fox fox = _foxPool.GetObject();
        fox.transform.position = _points[Random.Range(0, _points.Count)].position;
    }
}

