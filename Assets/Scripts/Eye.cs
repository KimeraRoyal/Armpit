using UnityEngine;

public class Eye : MonoBehaviour
{
    private Eyeball m_eyeball;

    [SerializeField] private Transform m_target;
    [SerializeField] private Transform m_cross;

    private void Awake()
    {
        m_eyeball = GetComponentInChildren<Eyeball>();
    }

    private void Update()
    {
        if(!m_target) { return; }
        
        var direction = (Vector2)(m_target.position - transform.position).normalized;
        
        var crossDistance = (Vector2)(m_cross.position - transform.position).normalized;
        direction = (direction + crossDistance) / 2.0f;

        transform.right = direction;
        m_eyeball.SetDistance(Mathf.Abs(Vector2.Dot(direction, Vector2.right)));
    }
}
