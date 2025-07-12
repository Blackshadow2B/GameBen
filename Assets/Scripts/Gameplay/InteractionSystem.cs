using UnityEngine;
using System.Collections.Generic;

public class InteractionSystem : MonoBehaviour
{
    public List<string> keys = new List<string>();

    public void CollectKey(string keyColor)
    {
        keys.Add(keyColor);
    }

    public bool HasKey(string keyColor)
    {
        return keys.Contains(keyColor);
    }

    public void OpenDoor(GameObject door)
    {
        // Logic to open the door
        door.SetActive(false);
    }

    public void DisableTrap(GameObject trap, float duration)
    {
        // Logic to disable the trap
        StartCoroutine(DisableTrapCoroutine(trap, duration));
    }

    private System.Collections.IEnumerator DisableTrapCoroutine(GameObject trap, float duration)
    {
        trap.SetActive(false);
        yield return new WaitForSeconds(duration);
        trap.SetActive(true);
    }
}
