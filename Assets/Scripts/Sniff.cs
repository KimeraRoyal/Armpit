using UnityEngine;

public class Sniff : MonoBehaviour
{
    private static readonly int s_sniffHash = Animator.StringToHash("Sniffing");

    private Nose m_nose;
    
    private Animator m_animator;

    [SerializeField] private float m_minSpeed = 1.0f;
    [SerializeField] private float m_maxSpeed = 1.0f;
    
    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();
        
        m_animator = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        m_nose.OnSniffingChanged += OnSniffingChanged;
        m_nose.OnTimerUpdated += OnTimerUpdated;
    }

    private void OnDisable()
    {
        m_nose.OnSniffingChanged -= OnSniffingChanged;
        m_nose.OnTimerUpdated -= OnTimerUpdated;
    }

    private void OnSniffingChanged(bool _sniffing)
    {
        m_animator.SetBool(s_sniffHash, _sniffing);
    }

    private void OnTimerUpdated(float _timer)
    {
        m_animator.speed = Mathf.Lerp(m_minSpeed, m_maxSpeed, m_nose.Progress);
    }
}
