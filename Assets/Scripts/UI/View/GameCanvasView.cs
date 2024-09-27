using UnityEngine;
using UnityEngine.UI;

public class GameCanvasView : MonoBehaviour
{
    [SerializeField] Text _bulletCountText;

    private SubscriptionProperty<int> _count = new SubscriptionProperty<int>();

    public void Initialize(SubscriptionProperty<int> count)
    {
        _count = count;
        _count.SubscribeOnChange(SetCount);
        SetCount();
    }    
    private void SetCount() =>
        _bulletCountText.text = _count.Value.ToString();
    private void OnDestroy() =>
    _count.UnSubscribeOnChange(SetCount);
}