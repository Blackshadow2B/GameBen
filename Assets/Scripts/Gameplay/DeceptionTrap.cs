using UnityEngine;

public class DeceptionTrap : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportLocation.position;
        }
    }
}
