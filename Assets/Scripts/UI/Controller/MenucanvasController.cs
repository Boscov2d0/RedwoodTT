public class MenucanvasController : ObjectsDisposer
{
    private readonly MyGameManager _gameManager;

    public MenucanvasController(MyGameManager gameManager)
    {
        _gameManager = gameManager;
        MenuCanvasView canvasView = ResourcesLoader.InstantiateAndGetObject<MenuCanvasView>("UI/MenuCanvas");
        canvasView.Initialize(Restart, Exit);
        AddGameObject(canvasView.gameObject);
    }
    private void Restart() => _gameManager.GameState.Value = States.GameStates.Restart;
    private void Exit() => _gameManager.GameState.Value = States.GameStates.Exit;
}