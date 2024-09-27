using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuCanvasView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private UnityAction _restartAction;
    private UnityAction _exitAction;

    public void Initialize(UnityAction restartAction, UnityAction exitAction) 
    {
        _restartAction = restartAction;
        _exitAction = exitAction;

        _restartButton.onClick.AddListener(_restartAction);
        _exitButton.onClick.AddListener(_exitAction);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(_restartAction);
        _exitButton.onClick.RemoveListener(_exitAction);
    }
}