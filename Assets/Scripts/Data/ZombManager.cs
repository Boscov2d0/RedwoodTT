using UnityEngine;

[CreateAssetMenu(fileName = nameof(ZombManager), menuName = "managers/" + nameof(ZombManager))]
public class ZombManager : ScriptableObject
{
    [field: SerializeField] public AnimatorOverrideController Controller { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float AnimSpeed { get; private set; }
    [field: SerializeField] public float HP { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int MinCountBullet { get; private set; }
    [field: SerializeField] public int MaxCountBullet { get; private set; }
    [field: SerializeField] public GameObject SpawnItem { get; private set; }
}