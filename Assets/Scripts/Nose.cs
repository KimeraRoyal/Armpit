using System;
using UnityEngine;

public class Nose : MonoBehaviour
{
    private Pit m_pit;

    [SerializeField] private float m_duration = 1.0f;
    [SerializeField] private float m_decaySpeed = 1.0f;

    private bool m_isSniffing;
    private bool m_isSniffingPit;
    
    private float m_timer;
    private bool m_clear;

    public bool IsSniffing
    {
        get => m_isSniffing;
        set
        {
            if(m_isSniffing == value) { return; }
            
            m_isSniffing = value;
            OnSniffingChanged?.Invoke(m_isSniffing);
        }
    }
    
    public bool IsSniffingPit
    {
        get => m_isSniffingPit;
        set
        {
            if(m_isSniffingPit == value) { return; }
            
            m_isSniffingPit = value;
            OnSniffingPitChanged?.Invoke(m_isSniffingPit);
        }
    }

    public float Timer
    {
        get => m_timer;
        private set
        {
            m_timer = value;
            OnTimerUpdated?.Invoke(m_timer);
        }
    }

    public float Progress => m_timer / m_duration;

    public Action<bool> OnSniffingChanged;
    public Action<bool> OnSniffingPitChanged;

    public Action<float> OnTimerUpdated;
    public Action OnClear;
    
    private void Awake()
    {
        m_pit = FindAnyObjectByType<Pit>();
    }

    private void Update()
    {
        IsSniffing = Input.GetMouseButton(0);
        IsSniffingPit = IsSniffing && m_pit.Contains(transform.position);
        
        if(m_clear) { return; }
        
        if (IsSniffingPit)
        {
            IncreaseTimer();
        }
        else
        {
            DecayTimer();
        }
    }

    private void IncreaseTimer()
    {
        Timer += Time.deltaTime;
        if(m_timer < m_duration) { return; }

        m_clear = true;
        OnClear?.Invoke();
    }

    private void DecayTimer()
    {
        if(Timer <= 0.0f) { return; }
        Timer = Mathf.Max(Timer - Time.deltaTime * m_decaySpeed, 0.0f);
    }
}
