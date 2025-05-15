using System.Collections.Generic;
using UnityEngine;

public partial class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private FoxPool _foxPool;    
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    [SerializeField] private Counter _counter;
    [SerializeField] private List<Transform> _points;
    
    private int chickCount;
    private int waveNumber = 4;
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;

    
    void Start()
    {
        _chickSpawner = new ChickSpawner(_chickPool, _points, _player, _explosionRedPool, _counter);
        _foxSpawner = new FoxSpawner(_foxPool, _points, _player);        
        _foxSpawner.SpawnFoxWave();        
    }   
    void Update()
    {
        chickCount = FindObjectsOfType<Chick>().Length;
        if (chickCount == 0)
        {
            waveNumber++;            
            _chickSpawner.SpawnChickWave(waveNumber);
        }
    }    
}
