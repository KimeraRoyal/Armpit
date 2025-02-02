using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Confetti : MonoBehaviour
{
    private Nose m_nose;

    private ParticleSystem m_particles;
    
    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();

        m_particles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        m_nose.OnClear += OnClear;
    }

    private void OnDisable()
    {
        m_nose.OnClear -= OnClear;
    }

    private void OnClear()
    {
        m_particles.Play();
    }
}
