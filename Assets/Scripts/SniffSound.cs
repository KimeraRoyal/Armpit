using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SniffSound : MonoBehaviour
{
    private Nose m_nose;

    private AudioSource m_sfx;

    [SerializeField] private float m_sfxVolume = 1.0f;
    [SerializeField] private float m_fadeOutTime = 1.0f;

    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();

        m_sfx = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        m_nose.OnSniffingPitChanged += OnSniffingPitChanged;
    }

    private void OnDisable()
    {
        m_nose.OnSniffingPitChanged -= OnSniffingPitChanged;
    }

    private void OnSniffingPitChanged(bool _sniffing)
    {
        if (_sniffing)
        {
            SniffStart();
        }
        else
        {
            SniffEnd();
        }
    }

    private void SniffStart()
    {
        if(m_nose.Clear) { return; }
        
        m_sfx.Play();
        m_sfx.volume = m_sfxVolume;
    }

    private void SniffEnd()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        for (var time = 0.0f; time < m_fadeOutTime; time += Time.deltaTime)
        {
            m_sfx.volume = Mathf.Lerp(m_sfxVolume, 0.0f, time / m_fadeOutTime);
            yield return null;
        }
        m_sfx.Stop();
    }
}
