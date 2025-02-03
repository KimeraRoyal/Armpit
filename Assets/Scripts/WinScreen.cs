using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class WinScreen : MonoBehaviour
{
    private static readonly int s_cleared = Animator.StringToHash("Win");
    
    private Nose m_nose;
    private LockMouse m_lockMouse;
    
    private Animator m_animator;
    private AudioSource m_sfx;
    
    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();
        m_lockMouse = FindAnyObjectByType<LockMouse>();

        m_animator = GetComponent<Animator>();
        m_sfx = GetComponent<AudioSource>();
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
        m_sfx.Play();

        m_lockMouse.CursorLockState = CursorLockMode.None;
        m_lockMouse.CursorVisible = true;
    }
}
