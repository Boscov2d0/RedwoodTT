using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private RaycastHit2D _hit;
    private float _direction;
    private float _timer;
    private bool _isActive;

    public bool IsActive { get { return _isActive; } private set { } }

    public void Initialize(float direction)
    {
        SetDirectionAndRotation(direction);

        _timer = _lifeTime;
        _isActive = true;
        gameObject.SetActive(_isActive);
    }
    private void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        if (_timer <= 0)
            Deactivate();

        _rigidbody.velocity = new Vector2(_direction * _speed, transform.position.y);

        _hit = Physics2D.Raycast(new Vector2(transform.position.x + 1.5f * _direction, transform.position.y),
                                 new Vector2(_direction, 0), _attackRange);
        if (!_hit.collider)
            return;

        if (_hit.collider.TryGetComponent(out ZombController zomb))
        {
            zomb.HitAction?.Invoke(_damage);
            Deactivate();
        }
    }
    private void SetDirectionAndRotation(float direction) 
    {
        if (direction < 0.5)
        {
            _direction = 1;
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            _direction = -1;
            transform.rotation = new Quaternion(0, 180, 0, 1);
        }
    }
    private void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(_isActive);
    }
}