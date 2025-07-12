using UnityEngine;

public class MovingWallTrap : MonoBehaviour
{
    public Vector3 moveOffset;
    public float moveSpeed = 2f;
    public float blockTime = 2f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMoving;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + moveOffset;
    }

    public void Activate()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveWall());
        }
    }

    private System.Collections.IEnumerator MoveWall()
    {
        float t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            t += Time.deltaTime * moveSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(blockTime);

        t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, t);
            t += Time.deltaTime * moveSpeed;
            yield return null;
        }

        isMoving = false;
    }
}
