using System.Collections.Generic;
using UnityEngine;

public partial class SpawnManager : MonoBehaviour
{
    [SerializeField] private FoxPool _foxPool;    
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    [SerializeField] private Transform _player;
    [SerializeField] private Counter _counter;
    [SerializeField] private List<Transform> _points;
    
    private int _chickCount;
    private int _waveNumber = 4;
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;
        
    void Start()
    {
        _chickSpawner = new ChickSpawner(_chickPool, _points, _player, _explosionRedPool, _counter, this);
        _foxSpawner = new FoxSpawner(_foxPool, _points, _player);        
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
