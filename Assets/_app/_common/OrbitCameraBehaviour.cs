using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitCameraBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference enableRotateAction;
    [SerializeField] private InputActionReference rotateAction;
    [SerializeField] private InputActionReference zoomAction;

    [SerializeField] private Transform target;

    [SerializeField] private float orbitSpeed = 75;
    [SerializeField] private Vector2 verticalAngleBoundaries = new(-75, 75);

    [SerializeField] private float distance = 5;
    [SerializeField] private Vector2 distanceBoundaries = new(1, 50);

    private float m_Yaw;
    private float m_Pitch;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("OrbitCamera: No target assigned.");
            enabled = false;
            return;
        }

        m_Yaw = transform.eulerAngles.y;
        m_Pitch = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        distance -= zoomAction.action.ReadValue<Vector2>().y * Time.deltaTime;
        distance = Mathf.Clamp(distance, distanceBoundaries.x, distanceBoundaries.y);

        if (enableRotateAction.action.phase == InputActionPhase.Performed)
        {
            var move = rotateAction.action.ReadValue<Vector2>() * (orbitSpeed * Time.deltaTime);

            m_Yaw += move.x;
            m_Pitch -= move.y; // Inversé pour correspondre aux mouvements naturels
            m_Pitch = Mathf.Clamp(m_Pitch, verticalAngleBoundaries.x, verticalAngleBoundaries.y);
        }

        var rotation = Quaternion.Euler(m_Pitch, m_Yaw, 0f);
        var offset = rotation * new Vector3(0, 0, -distance);

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}