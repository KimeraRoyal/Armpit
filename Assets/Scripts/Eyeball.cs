using UnityEngine;

public class Eyeball : MonoBehaviour
{
    [SerializeField] private Vector2 m_minDistance;
    [SerializeField] private Vector2 m_maxDistance;
    
    [SerializeField] private AnimationCurve m_curve = AnimationCurve.Linear(0, 0, 1, 1);

    public void SetDistance(float _t)
    {
        transform.localPosition = Vector2.Lerp(m_minDistance, m_maxDistance, m_curve.Evaluate(_t));
    }
}