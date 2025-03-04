using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCameraBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference buttonToEnableRotationAction;
    [SerializeField] private InputActionReference moveOrbitAction;

    [SerializeField] private float rotationSpeed = 75;
    [SerializeField] private Vector2 verticalAngleBoundaries = new(-75, 75);

    private float m_Yaw;
    private float m_Pitch;

    private void Start()
    {
        m_Yaw = transform.eulerAngles.y;
        m_Pitch = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        if (buttonToEnableRotationAction != null && buttonToEnableRotationAction.action.phase != InputActionPhase.Performed) return;

        var move = moveOrbitAction.action.ReadValue<Vector2>() * (rotationSpeed * Time.deltaTime);

        m_Yaw += move.x;
        m_Pitch -= move.y; // Inversé pour correspondre aux mouvements naturels
        m_Pitch = Mathf.Clamp(m_Pitch, verticalAngleBoundaries.x, verticalAngleBoundaries.y);

        transform.rotation = Quaternion.Euler(m_Pitch, m_Yaw, 0f);
    }
}