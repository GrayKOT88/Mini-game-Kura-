using UnityEngine;

[CreateAssetMenu(fileName = "AnimalSettings", menuName = "Game/AnimalSettings")]
public class AnimalSettings : ScriptableObject
{
    [Header("Player")]
    public int MaxHealth = 3;
    public float Speed = 11;
    public float YRange = 0.03f;
    [Space]
    [Header("Fox")]
    public float AttackRange = 1f;
    public float ChaseRange = 25f;
    public float PatrolTime = 180f;
    public float IdleTime = 5f;
    [Space]
    [Header("Chick")]
    public float FollowDistance = 10f;
    public float StopDistance = 1f;
    [Space]
    [Header("Spawn Manager")]
    public int WaveNumber = 4;
}
