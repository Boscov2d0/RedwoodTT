using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : ObjectsDisposer
{
    private readonly PlayerManager _manager;
    private readonly Transform _firePoint;
    private readonly Transform _body;

    private BulletController _bullet;
    private GameObject _bulletsPool;
    private List<BulletController> _bulletsPoolList = new List<BulletController>();

    private float _timer;
    private bool _canFire;
    private bool _isOneShoot;
    private bool _isSelected;
    private bool _isCreated;

    private int _index;

    public PlayerFireController(PlayerManager manager, Transform firePoint, Transform body)
    {
        _manager = manager;
        _firePoint = firePoint;
        _body = body;

        _manager.FireAction += Fire;

        _bulletsPool = new GameObject("BulletPool");

        CreateFirstBuller();
    }
    protected override void OnDispose()
    {
        _manager.FireAction -= Fire;
        _bulletsPoolList.Clear();

        base.OnDispose();
    }
    public void FixedExecute()
    {
        _timer -= Time.fixedDeltaTime;

        if (_timer <= 0)
            _canFire = true;
        else
            _canFire = false;

        if (_canFire && (_isOneShoot || _manager.IsFire.Value))
            Shoot();
    }
    private void Fire()
    {
        _isOneShoot = true;
    }
    private void CreateFirstBuller()
    {
        _bullet = GameObject.Instantiate(_manager.BulletPrefab, _bulletsPool.transform);
        _bullet.gameObject.SetActive(false);
        _bulletsPoolList.Add(_bullet);
    }
    private void Shoot()
    {
        _manager.ShootAction?.Invoke();

        _timer = _manager.ReloadTime;

        _manager.IsFire.Value = false;
        _isOneShoot = false;
        _isSelected = false;
        _isCreated = false;

        do
        {
            if (_index >= _bulletsPoolList.Count - 1)
            {
                _index = 0;
                _isSelected = true;
            }
            if (_bulletsPoolList[_index].IsActive)
                _index++;
            else
            {
                _bulletsPoolList[_index].Initialize(_body.rotation.y);
                _bulletsPoolList[_index].transform.position = _firePoint.position;
                _isSelected = true;
                _isCreated = true;
            }
        }
        while (!_isSelected);

        if (_isCreated)
            return;

        _bullet = GameObject.Instantiate(_manager.BulletPrefab, _bulletsPool.transform);
        _bulletsPoolList.Add(_bullet);
        _bullet.Initialize(_body.rotation.y);
        _bullet.transform.position = _firePoint.position;
    }
}