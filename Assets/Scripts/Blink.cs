using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Sniff))]
public class Blink : MonoBehaviour
{
    private static readonly int s_blinkHash = Animator.StringToHash("Blink");
    
    private Animator m_animator;
    private Nose m_nose;

    [SerializeField] private float m_minBlinkDelay = 1.0f;
    [SerializeField] private float m_maxBlinkDelay = 1.0f;
    
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_nose = FindAnyObjectByType<Nose>();
    }

    private void Start()
    {
        StartCoroutine(BlinkCycle());
    }

    private IEnumerator BlinkCycle()
    {
        while (true)
        {
            var blinkDelay = Random.Range(m_minBlinkDelay, m_maxBlinkDelay);
            yield return new WaitForSeconds(blinkDelay);
            
            if(m_nose.IsSniffing) { continue; }
            m_animator.SetTrigger(s_blinkHash);
        }
    }
}
