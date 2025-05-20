using System.Collections.Generic;
using UnityEngine;
using Zenject;

public partial class SpawnManager : MonoBehaviour
{
    private FoxPool _foxPool;
    private ChickPool _chickPool;
    private ExplosionRedPool _explosionRedPool;
    private Transform _player;
    private Counter _counter;
    private AnimalSettings _settings;
    private List<Transform> _points;

    private int _chickCount;
    private int _waveNumber = 4;
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;

    [Inject]
    public void Construct(FoxPool foxPool, ChickPool chickPool, ExplosionRedPool explosionRedPool,
        [Inject(Id = "Player")] Transform player, Counter counter, AnimalSettings settings,
        [Inject(Id = "SpawnPoints")] List<Transform> points)
    {
        _foxPool = foxPool;
        _chickPool = chickPool;
        _explosionRedPool = explosionRedPool;
        _player = player;
        _counter = counter;
        _settings = settings;
        _points = points;
    }

    void Start()
    {
        _chickSpawner = new ChickSpawner(_chickPool, _points, _player, _explosionRedPool, _counter, this, _settings);
        _foxSpawner = new FoxSpawner(_foxPool, _points, _player, _settings);
        _foxSpawner.SpawnFoxWave();
        StartWave();
    }

    public void UpdateWave()
    {
        _chickCount--;
        if (_chickCount == 0)
        {
            _waveNumber++;
            StartWave();
        }
    }

    private void StartWave()
    {
        _chickSpawner.SpawnChickWave(_waveNumber);
        _chickCount = _waveNumber; ;
    }
}