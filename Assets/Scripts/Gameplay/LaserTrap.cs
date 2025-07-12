using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float slowAmount = 0.5f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavigatorController navigator = other.GetComponent<NavigatorController>();
            if (navigator != null)
            {
                navigator.moveSpeed *= slowAmount;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NavigatorController navigator = other.GetComponent<NavigatorController>();
            if (navigator != null)
            {
                navigator.moveSpeed /= slowAmount;
            }
        }
    }
}
