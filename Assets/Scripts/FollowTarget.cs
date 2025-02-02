using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform m_target;

    [SerializeField] private Vector3 m_followAmount = Vector3.one;
    [SerializeField] private Vector3 m_followOffset;

    public Vector3 FollowAmount
    {
        get => m_followAmount;
        set => m_followAmount = value;
    }

    public Vector3 FollowOffset
    {
        get => m_followOffset;
        set => m_followOffset = value;
    }

    private void Update()
    {
        if(!m_target) { return; }

        var position = transform.position;
        for (var axis = 0; axis < 3; axis++)
        {
            position[axis] = m_target.position[axis] * m_followAmount[axis] + m_followOffset[axis];
        }
        transform.position = position;
    }
}
