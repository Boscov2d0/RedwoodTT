using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MyGameManager _gameManager;
    [SerializeField] private PlayerManager _playerManager;

    private GameController _gameController;
    private KeyboardInputController _keyboardInputController;
    private UIController _uiController;

    private void Awake()
    {
        LoadObjects();

        _keyboardInputController = new KeyboardInputController(_playerManager);
        _uiController = new UIController(_gameManager);
        _gameController = new GameController(_gameManager, _playerManager);
    }
    private void LoadObjects()
    {
        ResourcesLoader.InstantiateObject<GameObject>("Scenes");
        ResourcesLoader.InstantiateObject<SoundController>("SoundsController");
        PlayerController player = ResourcesLoader.InstantiateAndGetObject<PlayerController>("Player");
        CameraController camera = ResourcesLoader.InstantiateAndGetObject<CameraController>("Main Camera");
        camera.SetPlayer(player.transform);
        SpawnerController spawnerController = ResourcesLoader.InstantiateAndGetObject<SpawnerController>("Spawner");
        spawnerController.SetPlayer(player);
    }
    private void Update() => _keyboardInputController?.Execute();
    private void OnDestroy()
    {
        _gameController?.Dispose();
        _keyboardInputController?.Dispose();
        _uiController?.Dispose();
    }
}