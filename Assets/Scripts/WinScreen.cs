using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WinScreen : MonoBehaviour
{
    private static readonly int s_cleared = Animator.StringToHash("Win");
    
    private Nose m_nose;

    private Animator m_animator;
    
    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();

        m_animator = GetComponent<Animator>();
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
        m_animator.SetTrigger(s_cleared);
    }
}
