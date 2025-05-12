using System.Collections.Generic;
using UnityEngine;

public partial class SpawnManager : MonoBehaviour
{
    [SerializeField] ChickPool _chickPool;
    [SerializeField] FoxPool _foxPool;
    
    List<Transform> _points = new List<Transform>();    
    private int chickCount;
    private int waveNumber = 4;
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;

    
    void Start()
    {
        _chickSpawner = new ChickSpawner(_chickPool, _points);
        _foxSpawner = new FoxSpawner(_foxPool, _points);
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            _points.Add(t);
        }
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
