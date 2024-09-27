using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerManager), menuName = "managers/" + nameof(PlayerManager))]
public class PlayerManager : ScriptableObject
{
    public SubscriptionProperty<float> Horizontal = new SubscriptionProperty<float>();
    public SubscriptionProperty<bool> IsFire = new SubscriptionProperty<bool>();

    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float ReloadTime { get; private set; }
    [field: SerializeField] public BulletController BulletPrefab { get; private set; }

    public Action FireAction;
    public Action ShootAction;
}