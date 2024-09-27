using UnityEngine;

public class ZombAttackController : ObjectsDisposer
{
    private readonly MyGameManager _gameManager;
    private readonly Transform _transform;
    private ZombManager _zomnManager;
    private RaycastHit2D _hit;
    private float _direction;

    public ZombAttackController(MyGameManager gameManager, Transform transform)
    {
        _gameManager = gameManager;
        _transform = transform;
    }
    public void Initialize(ZombManager manager, float direction)
    {
        _zomnManager = manager;
        _direction = direction;
    }
    public void FixedExecute()
    {
        _hit = Physics2D.Raycast(new Vector2(_transform.position.x + 1.5f * _direction, _transform.position.y), 
                                 new Vector2(_direction, 0), _zomnManager.AttackRange);
        if (!_hit.collider)
            return;

        if (_hit.collider.TryGetComponent(out PlayerController player))
        {
            _gameManager.SoundState.Value = States.SoundStates.ZombAttack;
            _gameManager.GameState.Value = States.GameStates.GameOver;
        }
    }
}