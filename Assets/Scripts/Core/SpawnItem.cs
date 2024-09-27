using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private MyGameManager _gameManager;
    [SerializeField] private Text _countText;

    private int _count;

    public void Initialize(int count)
    {
        _count = count;
        _countText.text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            _gameManager.AddBulletAction?.Invoke(_count);
            _gameManager.SoundState.Value = States.SoundStates.PickUp;
            Destroy(gameObject);
        }
    }
}