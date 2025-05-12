using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fox : MonoBehaviour
{
    private float _attackRange = 1f;
    private float _chaseRange = 25f;
    private float _patrolTime = 180f;
    private float _idleTime = 5f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _player;
    private List<Transform> _patrolPoints;
    private StateMachine _stateMachine;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
        // Инициализация точек патрулирования
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        _patrolPoints = new List<Transform>();
        foreach (Transform t in pointsObject)
        {
            _patrolPoints.Add(t);
        }
        
        _stateMachine = new StateMachine();  // Инициализация машины состояний
        _stateMachine.ChangeState(new IdleState(this));
    }

    public void Initialize(Transform player)
    {
        _player = player;
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    // Свойства для доступа из состояний
    public NavMeshAgent Agent => _agent;
    public Animator Animator => _animator;
    public Transform Player => _player;
    public List<Transform> PatrolPoints => _patrolPoints;
    public float AttackRange => _attackRange;
    public float ChaseRange => _chaseRange;
    public float PatrolTime => _patrolTime;
    public float IdleTime => _idleTime;

    // Методы для изменения состояния
    public void SetIdle() => _stateMachine.ChangeState(new IdleState(this));
    public void SetChase() => _stateMachine.ChangeState(new ChaseState(this));
    public void SetAttack() => _stateMachine.ChangeState(new AttackState(this));
    public void SetPatrol() => _stateMachine.ChangeState(new PatrolState(this));
}