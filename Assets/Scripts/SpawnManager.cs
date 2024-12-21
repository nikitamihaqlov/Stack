using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _previousBlock;
    [SerializeField] private GameObject _currentBlock;
    [SerializeField] private GameObject _blockPrefab;

    public GameObject PreviousBlock => _previousBlock;
    public GameObject CurrentBlock => _currentBlock;

    public event Action BlockSpawned;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { SpawnBlock(); }
    }

    private void SpawnBlock()
    {
        _previousBlock = _currentBlock;
        _currentBlock = Instantiate(_blockPrefab, GenerateSpawnPosition(), _blockPrefab.transform.rotation);

        BlockSpawned?.Invoke();
    }

    private Vector3 GenerateSpawnPosition()
    {
        var previousBlockHeight = _previousBlock.transform.localScale.y;
        var blockPrefabHeight = _blockPrefab.transform.localScale.y;
        var offset = _previousBlock.transform.up * (previousBlockHeight + blockPrefabHeight) / 2;

        var position = _previousBlock.transform.position + offset;
        return position;
    }
}
