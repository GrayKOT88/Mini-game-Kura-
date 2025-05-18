using System.Collections.Generic;
using UnityEngine;

public partial class SpawnManager : MonoBehaviour
{
    [SerializeField] private FoxPool _foxPool;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    [SerializeField] private Transform _player;
    [SerializeField] private Counter _counter;
    [SerializeField] private AnimalSettings _settings;
    [SerializeField] private List<Transform> _points;

    private int _chickCount;    
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;

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
            _settings.WaveNumber++;
            StartWave();
        }
    }

    private void StartWave()
    {
        _chickSpawner.SpawnChickWave(_settings.WaveNumber);
        _chickCount = _settings.WaveNumber; ;
    }
}