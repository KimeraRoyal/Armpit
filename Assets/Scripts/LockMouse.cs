using UnityEngine;

public class LockMouse : MonoBehaviour
{
    [SerializeField] private CursorLockMode m_cursorLockState = CursorLockMode.Confined;
    [SerializeField] private bool m_cursorVisible;

    private bool m_initialSet;

    public CursorLockMode CursorLockState
    {
        get => m_cursorLockState;
        set
        {
            m_cursorLockState = value;
            UpdateLockSettings();
        }
    }

    public bool CursorVisible
    {
        get => m_cursorVisible;
        set
        {
            m_cursorVisible = value;
            UpdateLockSettings();
        }
    }
    
    private void Update()
    {
        if (m_initialSet || !Input.GetMouseButtonDown(0)) { return; }
        
        UpdateLockSettings();
        m_initialSet = true;
    }

    private void UpdateLockSettings()
    {
        Cursor.lockState = m_cursorLockState;
        Cursor.visible = m_cursorVisible;
    }
}
