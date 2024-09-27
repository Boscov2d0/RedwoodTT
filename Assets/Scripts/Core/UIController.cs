public class UIController : ObjectsDisposer
{
    private readonly MyGameManager _gameManager;

    private GameCanvasController _gameCanvasController;
    private MenucanvasController _menuCanvasController;

    public UIController(MyGameManager gameManager) 
    {
        _gameManager = gameManager;

        _gameManager.GameState.SubscribeOnChange(OnStateChange);
    }
    private void OnStateChange() 
    {
        DisposeControllers();

        switch (_gameManager.GameState.Value) 
        {
            case States.GameStates.Game:
                _gameCanvasController = new GameCanvasController(_gameManager.CurrentBulletCount);
                break;
            case States.GameStates.GameOver:
                _menuCanvasController = new MenucanvasController(_gameManager);
                break;
        }
    }
    protected override void OnDispose()
    {
        _gameManager.GameState.UnSubscribeOnChange(OnStateChange);

        DisposeControllers();

        base.OnDispose();
    }
    private void DisposeControllers() 
    {
        _gameCanvasController?.Dispose();
        _menuCanvasController?.Dispose();
    }
}