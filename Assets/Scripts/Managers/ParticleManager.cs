using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }

    // Particle systems
    public ParticleSystem trapActivationParticles;
    public ParticleSystem keyCollectionParticles;
    public ParticleSystem explosionParticles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayParticles(ParticleSystem particles, Vector3 position)
    {
        particles.transform.position = position;
        particles.Play();
    }
}
