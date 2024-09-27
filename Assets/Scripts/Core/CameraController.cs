using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    
    private Vector3 _offset;
    private Vector3 _desiredPos;
    private Vector3 _smoothPos;

    private float _clampedX;

    public void SetPlayer(Transform player) => _player = player;
    
    private void FixedUpdate()
    {
        _desiredPos = _player.position + _offset;
        _smoothPos = Vector3.Lerp(transform.position, _desiredPos, _speed);

        _clampedX = Mathf.Clamp(_smoothPos.x, _minX, _maxX);

        transform.position = new Vector3(_clampedX, 1, -10);
    }
}