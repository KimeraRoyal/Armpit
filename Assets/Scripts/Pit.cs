using UnityEngine;

public class Pit : MonoBehaviour
{
    [SerializeField] private float m_radius = 1.0f;

    public float Radius => m_radius;

    public bool Contains(Vector2 _point)
    {
        return ((Vector2)transform.position - _point).magnitude < m_radius;
    }
}
