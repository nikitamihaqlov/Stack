using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _offset;

    [SerializeField] private SpawnManager _spawnManager;

    private void OnEnable()
    {
        _spawnManager.BlockSpawned += UpdatePosition;
    }

    private void OnDisable()
    {
        _spawnManager.BlockSpawned -= UpdatePosition;
    }

    private void Start()
    {
        _targetPosition = transform.position;
        _offset = transform.position - _spawnManager.CurrentBlock.transform.position;
    }

    private void LateUpdate()
    {
        if ((transform.position - _targetPosition).magnitude < 0.001f)
        {
            transform.position = _targetPosition;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
        }
    }

    private void UpdatePosition()
    {
        _targetPosition = new Vector3(transform.position.x, 
            _spawnManager.CurrentBlock.transform.position.y + _offset.y, 
            transform.position.z);
    }
}
