using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Sniff))]
public class Armpit : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField] private Transform m_target;

    [SerializeField] private float m_minDistance = 0.0f;
    [SerializeField] private float m_maxDistance = 1.0f;

    [SerializeField] private float m_minSpeed = 1.0f;
    [SerializeField] private float m_maxSpeed = 1.0f;
    
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var distance = ((Vector2)(transform.position - m_target.position)).magnitude;
        distance = Mathf.Clamp(distance, m_minDistance, m_maxDistance);

        var t = (distance - m_minDistance) / (m_maxDistance - m_minDistance);
        m_animator.speed = Mathf.Lerp(m_minSpeed, m_maxSpeed, t);
    }
}
