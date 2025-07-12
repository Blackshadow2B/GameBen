using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    public float collapseTime = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Collapse", collapseTime);
        }
    }

    private void Collapse()
    {
        // Add visual/audio feedback before destroying
        Destroy(gameObject);
    }
}
