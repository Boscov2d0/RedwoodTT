using UnityEngine;

public class PlayerAnimatorController : ObjectsDisposer
{
    private readonly PlayerManager _playerManager;
    private readonly Animator _animator;
    private int _direction;

    public PlayerAnimatorController(PlayerManager playerManager, Animator animator)
    {
        _playerManager = playerManager;
        _animator = animator;

        _playerManager.Horizontal.SubscribeOnChange(GetDirection);
        _playerManager.IsFire.SubscribeOnChange(SetAnimatorFireValue);
        _playerManager.FireAction += SetAnimatorOneShoot;
    }
    protected override void OnDispose()
    {
        _playerManager.Horizontal.UnSubscribeOnChange(GetDirection);
        _playerManager.IsFire.UnSubscribeOnChange(SetAnimatorFireValue);
        _playerManager.FireAction -= SetAnimatorOneShoot;

        base.OnDispose();
    }
    private void GetDirection()
    {
        _direction = _playerManager.Horizontal.Value > 0 ? 1 : -1;
        if (_playerManager.Horizontal.Value == 0)
            _direction = 0;
        SetAnimatorMoveValue();
    }
    private void SetAnimatorMoveValue() =>
        _animator.SetInteger("Horizontal", _direction);
    private void SetAnimatorFireValue() =>
        _animator.SetBool("IsFire", _playerManager.IsFire.Value);
    private void SetAnimatorOneShoot() =>
        _animator.SetTrigger("Fire");
}
