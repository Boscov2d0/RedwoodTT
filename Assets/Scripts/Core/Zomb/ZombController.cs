using System;
using UnityEngine;
using UnityEngine.UI;

public class ZombController : MonoBehaviour
{
    [SerializeField] private MyGameManager _gameManager;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _body;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _hpBarImage;

    private ZombManager _manager;
    private float _damage;

    private ZombMoveController _moveController;
    private ZombDeathController _deathController;
    private ZombUIController _uiController;
    private ZombAttackController _attackController;

    public Action<float> HitAction;

    public void Initialize(ZombManager manager, float direction)
    {
        _manager = manager;
        _animator.runtimeAnimatorController = _manager.Controller;
        _animator.SetFloat("Speed", _manager.AnimSpeed);

        _moveController?.Initialize(_manager, direction);
        _deathController?.Initialize(_manager);
        _uiController?.Initialize(_manager);
        _attackController?.Initialize(_manager, direction);

        HitAction += Hit;
    }
    private void Start()
    {
        _moveController = new ZombMoveController(_rigidbody, _body);
        _deathController = new ZombDeathController(_gameManager, gameObject);
        _uiController = new ZombUIController(_hpBarImage);
        _attackController = new ZombAttackController(_gameManager, _body);

        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        _moveController?.FixedExecute();
        _attackController?.FixedExecute();
    }
    private void OnDestroy()
    {
        HitAction -= Hit;

        _moveController?.Dispose();
        _deathController?.Dispose();
        _uiController?.Dispose();
        _attackController?.Dispose();
    }
    private void Hit(float damage)
    {
        _damage = damage;
        _deathController.OnHealthChange(_damage);
        _uiController.SetHPBar(_deathController.CurrentHP);
    }
}