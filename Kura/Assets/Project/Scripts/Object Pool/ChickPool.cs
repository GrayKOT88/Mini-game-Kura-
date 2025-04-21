
using System.Collections.Generic;
using UnityEngine;

public class ChickPool : MonoBehaviour, IObjectPool<Chick>
{
    [SerializeField] private Chick _prefabChick;
    [SerializeField] private Transform _playerTransform;
    private int _chickPoolSize = 5;

    private Queue<Chick> _chickPool = new Queue<Chick>();

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < _chickPoolSize; i++)
        {
            ExpandPool();
        }
    }

    private void ExpandPool()
    {
        Chick chick = Instantiate(_prefabChick, transform);
        chick.gameObject.SetActive(false);
        _chickPool.Enqueue(chick);
        chick.Initialize(this, _playerTransform);
    }

    public Chick GetObject()
    {
        if (_chickPool.Count == 0)
        {
            ExpandPool();
        }
        Chick chick = _chickPool.Dequeue();
        chick.gameObject.SetActive(true);
        return chick;
    }

    public void ReturnObject(Chick chick)
    {
        chick.gameObject.SetActive(false);        
        _chickPool.Enqueue(chick);
    }
}
