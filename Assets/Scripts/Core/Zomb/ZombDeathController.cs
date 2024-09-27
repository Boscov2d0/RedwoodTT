using UnityEngine;

public class ZombDeathController : ObjectsDisposer
{
    private readonly MyGameManager _gameManager;
    private readonly GameObject _obj;
    private ZombManager _zombManager;

    private float _currentHP;

    public float CurrentHP { get { return _currentHP; } private set { } }

    public ZombDeathController(MyGameManager gameManager, GameObject obj)
    {
        _gameManager = gameManager;
        _obj = obj;
    }

    public void Initialize(ZombManager manager)
    {
        _zombManager = manager;
        _currentHP = _zombManager.HP;
    }

    public void OnHealthChange(float damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
            Dead();        
    }
    private void Dead()
    {
        SpawnItem();
        _gameManager.SoundState.Value = States.SoundStates.ZombDead;
        _obj.SetActive(false);
    }
    private void SpawnItem()
    {
        SpawnItem item = GameObject.Instantiate(_zombManager.SpawnItem).GetComponent<SpawnItem>();
        item.Initialize(Random.Range(_zombManager.MinCountBullet, _zombManager.MaxCountBullet + 1));
        item.transform.position = _obj.transform.position;
    }
}