using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject previousBlock;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBlock();
        }
    }

    private void SpawnBlock()
    {
        previousBlock = block;
        previousBlock.GetComponent<BlockController>().Stop();
        Vector3 position = new Vector3(block.transform.position.x,
                block.transform.position.y + block.transform.localScale.y,
                block.transform.position.z);
        block = Instantiate(block, position, block.transform.rotation);
        block.GetComponent<BlockController>().ChangeDirection(previousBlock);
        mainCamera.transform.Translate(Vector3.up * block.transform.localScale.y, Space.World);
    }
}
