using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private MyGameManager _gameManager;
    [SerializeField] private AudioSource _zombAttackSound;
    [SerializeField] private AudioSource _zombDeadSound;
    [SerializeField] private AudioSource _pickupSound;

    private void Start() =>
        _gameManager.SoundState.SubscribeOnChange(OnSoundPlay);
    private void OnSoundPlay()
    {
        switch (_gameManager.SoundState.Value)
        {
            case States.SoundStates.ZombAttack: 
                _zombAttackSound.Play(); 
                break;
            case States.SoundStates.ZombDead: 
                _zombDeadSound.Play(); 
                break;
            case States.SoundStates.PickUp:
                _pickupSound.Play(); 
                break;
        }
    }
    private void OnDestroy() =>
        _gameManager.SoundState.UnSubscribeOnChange(OnSoundPlay);
}