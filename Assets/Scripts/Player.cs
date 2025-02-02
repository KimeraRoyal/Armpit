using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_maxMouseMovement = 1.0f;
    
    [SerializeField] private float m_minPosition;
    [SerializeField] private float m_maxPosition;

    [SerializeField] private float m_movementSpeed = 1.0f;
    [SerializeField] private float m_movementSmoothTime = 1.0f;
    
    [SerializeField] private float m_minRotation;
    [SerializeField] private float m_maxRotation;

    [SerializeField] private float m_rotationSpeed = 1.0f;
    [SerializeField] private float m_rotationSmoothTime = 1.0f;

    private float m_targetPosition;
    private float m_movementVelocity;
    
    private float m_targetRotation;
    private float m_currentRotation;
    private float m_rotationVelocity;

    private void Start()
    {
        m_targetPosition = transform.localPosition.x;
        
        m_targetRotation = transform.localEulerAngles.z;
        m_currentRotation = m_targetRotation;
    }

    private void Update()
    {
        GetMovement();
        GetRotation();

        CalculateMovement();
        CalculateRotation();
    }

    private void GetMovement()
    {
        var mouseX = Input.GetAxis("Mouse X");
        mouseX = Mathf.Clamp(mouseX, -m_maxMouseMovement, m_maxMouseMovement);

        m_targetPosition += mouseX * m_movementSpeed;
        m_targetPosition = Mathf.Clamp(m_targetPosition, m_minPosition, m_maxPosition);
    }

    private void GetRotation()
    {
        var mouseY = Input.GetAxis("Mouse Y");

        m_targetRotation += mouseY * m_rotationSpeed;
        m_targetRotation = Mathf.Clamp(m_targetRotation, m_minRotation, m_maxRotation);
        m_currentRotation = Mathf.SmoothDamp(m_currentRotation, m_targetRotation, ref m_rotationVelocity, m_rotationSmoothTime);
    }

    private void CalculateMovement()
    {
        var position = transform.localPosition;
        position.x = Mathf.SmoothDamp(position.x, m_targetPosition, ref m_movementVelocity, m_movementSmoothTime);
        transform.localPosition = position;
    }

    private void CalculateRotation()
    {
        var eulerAngles = transform.localEulerAngles;
        eulerAngles.z = m_currentRotation;
        transform.localEulerAngles = eulerAngles;
    }
}
