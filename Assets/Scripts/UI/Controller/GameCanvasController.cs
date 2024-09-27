public class GameCanvasController : ObjectsDisposer
{
    public GameCanvasController(SubscriptionProperty<int> count) 
    {
        GameCanvasView _canvasView = ResourcesLoader.InstantiateAndGetObject<GameCanvasView>("UI/GameCanvas");
        _canvasView.Initialize(count);
        AddGameObject(_canvasView.gameObject);
    }
}