using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ObjectsDisposer
{
    private readonly MyGameManager _gameManager;
    private readonly PlayerManager _playerManager;

    public GameController(MyGameManager gameManager, PlayerManager playerManager) 
    {
        _gameManager = gameManager;
        _playerManager = playerManager;

        Initialize();
    }  
    protected override void OnDispose()
    {
        _gameManager.GameState.UnSubscribeOnChange(OnStateChange);
        _gameManager.AddBulletAction -= AddBullet;
        _playerManager.ShootAction -= OnBulletChange;

        base.OnDispose();
    }
    private void Initialize()
    {
        Time.timeScale = 1;

        _gameManager.GameState.SubscribeOnChange(OnStateChange);
        _gameManager.AddBulletAction += AddBullet;
        _playerManager.ShootAction += OnBulletChange;

        _gameManager.CurrentBulletCount.Value = _gameManager.BulletCount;
        _gameManager.GameState.Value = States.GameStates.Game;
    }
    private void OnStateChange()
    {
        switch (_gameManager.GameState.Value)
        {
            case States.GameStates.Restart:
                Restart();
                break;
            case States.GameStates.GameOver:
                GameOver();
                break;
            case States.GameStates.Exit:
                Exit();
                break;
        }
    }
    private void OnBulletChange()
    {
        _gameManager.CurrentBulletCount.Value--;
        if (_gameManager.CurrentBulletCount.Value <= 0)
            _gameManager.GameState.Value = States.GameStates.GameOver;
    }
    private void AddBullet(int count) =>
        _gameManager.CurrentBulletCount.Value += count;
    private void Restart() => SceneManager.LoadScene(0);
    private void GameOver() => Time.timeScale = 0;
    private void Exit() => Application.Quit();
}