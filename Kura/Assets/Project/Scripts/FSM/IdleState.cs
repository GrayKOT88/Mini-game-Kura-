using UnityEngine;

public class IdleState : State
{
    private float timer;

    public IdleState(Fox fox) : base(fox) { }

    public override void Enter()
    {
        timer = 0f;
        fox.Agent.isStopped = true;
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        // �������� ���������� �� ������
        float distanceToPlayer = Vector3.Distance(fox.transform.position, fox.Player.position);
        if (distanceToPlayer < fox.ChaseRange)
        {
            fox.SetChase();
            return;
        }

        // ������� � �������������� ����� �����������
        if (timer > fox.IdleTime)
        {
            fox.SetPatrol();
        }
    }

    public override void Exit()
    {
        fox.Agent.isStopped = false;
    }
}