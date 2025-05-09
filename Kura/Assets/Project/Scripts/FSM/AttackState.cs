using UnityEngine;

public class AttackState : State
{
    public AttackState(Fox fox) : base(fox) { }

    public override void Enter()
    {
        // ����� ����� �������� �������� ����� ��� ������ �������
    }

    public override void Update()
    {
        float distance = Vector3.Distance(fox.transform.position, fox.Player.position);
        if (distance > fox.AttackRange)
        {
            fox.SetChase();
        }
    }

    public override void Exit()
    {
        // ����� �� ��������� �����
    }
}