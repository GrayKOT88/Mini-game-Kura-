using System.Collections.Generic;
using UnityEngine;

public partial class SpawnManager : MonoBehaviour
{
    [SerializeField] ChickPool _chickPool;
    [SerializeField] GameObject foxPrefab;
    List<Transform> _points = new List<Transform>();    
    private int chickCount;
    private int waveNumber = 4;
    private ChickSpawner _spawnSpawner;
    
    void Start()
    {
        _spawnSpawner = new ChickSpawner(_chickPool, _points);
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObject)
        {
            _points.Add(t);
        }
        SpawnFox();
    }   
    void Update()
    {
        chickCount = FindObjectsOfType<Chick>().Length;
        if (chickCount == 0)
        {
            waveNumber++;            
            _spawnSpawner.SpawnChickWave(waveNumber);
        }
    }
    
    void SpawnFox()
    {
        Instantiate(foxPrefab, (_points[Random.Range(0, _points.Count)].position), foxPrefab.transform.rotation);
        if(Progress.Instance.PlayerInfo.saveChick >= 50) 
        {
            Instantiate(foxPrefab, (_points[Random.Range(0, _points.Count)].position), foxPrefab.transform.rotation);
        }
        if(Progress.Instance.PlayerInfo.saveChick >= 100) 
        {
            Instantiate(foxPrefab, (_points[Random.Range(0, _points.Count)].position), foxPrefab.transform.rotation);
        }
    }
}
