using UnityEngine;

public class Tile
{
    public int x;
    public int y;
    public bool visited;

    public bool hasTopWall = true;
    public bool hasBottomWall = true;
    public bool hasLeftWall = true;
    public bool hasRightWall = true;
}
