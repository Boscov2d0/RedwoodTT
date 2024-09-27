using UnityEngine;

public class PlayerMoveController : ObjectsDisposer
{
    private readonly PlayerManager _playerManager;
    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _body;

    public PlayerMoveController(PlayerManager playerManager, Rigidbody2D rigidbody, Transform body)
    {
        _playerManager = playerManager;
        _rigidbody = rigidbody;
        _body = body;
    }
    public void FixedExecute() => Move();
    private void Move()
    {
        _rigidbody.velocity = new Vector2(_playerManager.Horizontal.Value * _playerManager.MoveSpeed, 0);

        if (_playerManager.Horizontal.Value > 0)
            _body.rotation = new Quaternion(0, 0, 0, 1);
        if (_playerManager.Horizontal.Value < 0)
            _body.rotation = new Quaternion(0, 180, 0, 1);
    }
}