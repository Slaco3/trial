using UnityEngine;

public class RaycastBehavior : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject origin;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private Color _rayColor = Color.red;
    private Vector3 _rayEndPosition;

    private void Update()
    {
        Rotate();
        Raycast();
        DrawLine();
    }

    private void Rotate()
    {
        var angleToAdd = Mathf.PingPong(Time.time * rotationSpeed, maxAngle - minAngle) + minAngle;
        transform.rotation = Quaternion.Euler(0, angleToAdd, 0);
    }

    private void Raycast()
    {
        var ray = new Ray(origin.transform.position, origin.transform.forward);

        if (Physics.Raycast(ray, out var hit))
        {
            _rayColor = Color.green;
            _rayEndPosition = hit.point;
        }
        else
        {
            _rayColor = Color.red;
            _rayEndPosition = origin.transform.position + origin.transform.forward * 10f;
        }
    }

    private void DrawLine()
    {
        lineRenderer.SetPosition(0, origin.transform.position);
        lineRenderer.SetPosition(1, _rayEndPosition);

        lineRenderer.startColor = lineRenderer.endColor = _rayColor;
    }
}