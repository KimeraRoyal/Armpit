using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    private Nose m_nose;
    
    private Camera m_camera;
    private FollowTarget m_followTarget;

    [SerializeField] private float m_minZoom = 1.0f;
    [SerializeField] private float m_maxZoom = 1.0f;

    [SerializeField] private float m_minCameraFollow = 1.0f;
    [SerializeField] private float m_maxCameraFollow = 1.0f;
    
    private void Awake()
    {
        m_nose = FindAnyObjectByType<Nose>();
        
        m_camera = GetComponent<Camera>();
        m_followTarget = GetComponent<FollowTarget>();
    }

    private void OnEnable()
    {
        m_nose.OnTimerUpdated += OnTimerUpdated;
    }

    private void OnDisable()
    {
        m_nose.OnTimerUpdated -= OnTimerUpdated;
    }

    private void OnTimerUpdated(float _timer)
    {
        m_camera.orthographicSize = Mathf.Lerp(m_minZoom, m_maxZoom, m_nose.Progress);
        m_followTarget.FollowAmount = Mathf.Lerp(m_minCameraFollow, m_maxCameraFollow, m_nose.Progress) * Vector3.right;
    }
}
