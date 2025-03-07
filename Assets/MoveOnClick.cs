using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveOnClick : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference moveCharacterAction;
    [SerializeField] private InputActionReference rotateCharacterAction;

    [SerializeField] private float moveSpeed = 75;
    [SerializeField] private float rotationSpeed = 75;
    private float m_Yaw;
    private float m_Pitch;
    private bool grounded;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void OnEnable()
    {
        if (jumpAction != null)
        {
            jumpAction.action.performed += OnJumpPerformed;
        }
    }


    private void OnDisable()
    {
        if (jumpAction != null)
        {
            jumpAction.action.performed -= OnJumpPerformed;
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        var rotate = rotateCharacterAction.action.ReadValue<Vector2>();
        // transform.Rotate(transform.localRotation.x + rotate.x * rotationSpeed, 0f, 0f);
        rb.AddTorque(transform.localRotation.x + rotate.x * rotationSpeed, 0f, 0f);

        if (grounded) {
        var move = moveCharacterAction.action.ReadValue<Vector2>() * moveSpeed;
        rb.AddForce(transform.forward * move.x * moveSpeed);
        }
    }
}