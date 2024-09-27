using UnityEngine;

public class ZombMoveController : ObjectsDisposer
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _body;
    private ZombManager _manager;
    private float _direction;

    public ZombMoveController(Rigidbody2D rigidbody, Transform body)
    { 
        _rigidbody = rigidbody;
        _body = body;
    }
    public void Initialize(ZombManager manager, float direction)
    {
        _manager = manager;
        _direction = direction;
        SetRotation();
    }
    public void FixedExecute() => Move();
    private void Move()
    {
        _rigidbody.velocity = new Vector2(_direction * _manager.MoveSpeed, _body.transform.position.y);
    }
    private void SetRotation()
    {
        int rotation = _direction >= 0 ? 0 : 180;
        _body.rotation = new Quaternion(0, rotation, 0, 1);
    }
}