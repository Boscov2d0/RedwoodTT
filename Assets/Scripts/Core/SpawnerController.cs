using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private MyGameManager _gameManager;
    [SerializeField] private List<ZombController> _zombs;
    [SerializeField] private List<ZombManager> _zombsManagers;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private PlayerController _playerController;

    private int _index;
    private float _timer;
    private float _direction;
    private Vector3 _newPos;

    public void SetPlayer(PlayerController playerController) => _playerController = playerController;

    private void Start() =>
        _timer = Random.Range(_minSpawnTime, _maxSpawnTime + 1);
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Spawn();
            _timer = Random.Range(_minSpawnTime, _maxSpawnTime + 1);
        }
    }
    private void Spawn()
    {
        GetSetPosition();
        GetDirection();

        if (_index >= _zombs.Count)
            _index = 0;

        _zombs[_index].Initialize(_zombsManagers[Random.Range(0, _zombsManagers.Count)], _direction);
        _zombs[_index].transform.position = _newPos;
        _zombs[_index].gameObject.SetActive(true);
        _index++;
    }
    private void GetDirection()
    {
        if (_playerController.transform.position.x >= _newPos.x)
            _direction = 1;
        else
            _direction = -1;
    }
    private void GetSetPosition()
    {
        int r = Random.Range(0, 2);
        float pos = r == 0 ? _gameManager.PosXMin : _gameManager.PosXMax;
        _newPos = new Vector3(pos, _gameManager.PosY, 0);
    }
}