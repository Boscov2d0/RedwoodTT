using UnityEngine;

public class KeyboardInputController : ObjectsDisposer
{
    private PlayerManager _playerManager;

    public KeyboardInputController(PlayerManager playerManager) 
    {
        _playerManager = playerManager;
    }

    public void Execute()
    {
        _playerManager.Horizontal.Value = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
            _playerManager.FireAction?.Invoke();
        _playerManager.IsFire.Value = Input.GetMouseButton(1);
    }
}