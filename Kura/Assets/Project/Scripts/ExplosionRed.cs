using System.Collections;
using UnityEngine;

public class ExplosionRed : MonoBehaviour
{
    private ExplosionRedPool _pool;
    private float _returnTime = 2f;

    public void Initialize(ExplosionRedPool pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        StartCoroutine(ReturnInPool());        
    }

    private IEnumerator ReturnInPool()
    {
        yield return new WaitForSeconds(_returnTime);
        _pool.ReturnObject(this);
    }
}
