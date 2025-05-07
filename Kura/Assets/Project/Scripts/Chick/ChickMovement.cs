using UnityEngine;
using UnityEngine.AI;

public class ChickMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _target;
    private float _followDistance = 10f;
    private float _stopDistance = 1f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null) return;

        float distance = Vector3.Distance(transform.position, _target.position);

        if (distance >= _followDistance)
        {
            StandStill();
        }
        else if (distance < _followDistance && distance > _stopDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.position);
            _animator.SetFloat("Speed_f", 1);
        }
        else if (distance <= _stopDistance)
        {
            StandStill();
        }
    }

    private void StandStill()
    {
        _agent.isStopped = true;
        _animator.SetFloat("Speed_f", 0);
    }
}
