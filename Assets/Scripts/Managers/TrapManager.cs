using UnityEngine;
using System.Collections.Generic;

public class TrapManager : MonoBehaviour
{
    public float trapCooldown = 3f;
    private float lastTrapTime;

    public void PlaceTrap(GameObject trapPrefab, Vector3 position)
    {
        if (Time.time - lastTrapTime > trapCooldown)
        {
            Instantiate(trapPrefab, position, Quaternion.identity);
            lastTrapTime = Time.time;
        }
    }
}
