using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _firePoint;

    private PlayerMoveController _moveController;
    private PlayerFireController _fireController;
    private PlayerAnimatorController _animatorController;

    //public float GetDirection()
    //{
    //    float direction = _playerManager.Horizontal.Value >= 0 ? 1 : -1;
    //    return direction;
    //}

    private void Start()
    {
        _moveController = new PlayerMoveController(_playerManager, _rigidbody, _body);
        _fireController = new PlayerFireController(_playerManager, _firePoint, _body);
        _animatorController = new PlayerAnimatorController(_playerManager, _animator);
    }

    private void FixedUpdate()
    {
        _moveController?.FixedExecute();
        _fireController?.FixedExecute();
    }
    private void OnDestroy()
    {
        _moveController?.Dispose();
        _fireController?.Dispose();
        _animatorController?.Dispose();
    }
}