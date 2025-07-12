using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    private MazeGenerator mazeGenerator;

    private void Start()
    {
        mazeGenerator = FindObjectOfType<MazeGenerator>();
    }

    public bool IsValidPosition(int x, int y)
    {
        if (x < 0 || x >= mazeGenerator.width || y < 0 || y >= mazeGenerator.height)
        {
            return false;
        }

        // Additional logic to check for obstacles, etc.

        return true;
    }

    public Vector3 GetRandomValidPosition()
    {
        int x, y;
        do
        {
            x = Random.Range(0, mazeGenerator.width);
            y = Random.Range(0, mazeGenerator.height);
        } while (!IsValidPosition(x, y));

        return new Vector3(x, 0, y);
    }
}
