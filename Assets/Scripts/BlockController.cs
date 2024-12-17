using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Vector3 direction = Vector3.forward;
    private float speed = 1;
    private float zRange = 1;
    private float xRange = 1;

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.z > zRange)
        {
            direction = Vector3.back;
        }
        else if (transform.position.z < -zRange)
        {
            direction = Vector3.forward;
        }
        else if (transform.position.x > xRange)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x < -xRange)
        {
            direction = Vector3.right;
        }
    }

    public void Stop()
    {
        speed = 0;
    }

    public void ChangeDirection(GameObject previousBlock)
    {
        if (previousBlock.GetComponent<BlockController>().direction == Vector3.forward ||
            previousBlock.GetComponent<BlockController>().direction == Vector3.back)
        {
            direction = Vector3.right;
        }
        else if (previousBlock.GetComponent<BlockController>().direction == Vector3.right ||
            previousBlock.GetComponent<BlockController>().direction == Vector3.left)
        {
            direction = Vector3.forward;
        }
    }
}
