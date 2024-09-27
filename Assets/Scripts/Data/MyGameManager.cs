using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MyGameManager), menuName = "managers/" + nameof(MyGameManager))]
public class MyGameManager : ScriptableObject
{
    public SubscriptionProperty<States.GameStates> GameState = new SubscriptionProperty<States.GameStates>();
    public SubscriptionProperty<States.SoundStates> SoundState = new SubscriptionProperty<States.SoundStates>();
    public SubscriptionProperty<int> CurrentBulletCount = new SubscriptionProperty<int>();
    [field: SerializeField] public int BulletCount { get; private set; }
    [field: SerializeField] public float PosXMin { get; private set; }
    [field: SerializeField] public float PosXMax { get; private set; }
    [field: SerializeField] public float PosY { get; private set; }
    public Action<int> AddBulletAction;
}