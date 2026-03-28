using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float jumpPower = 1.0f;
    public float rotateSpeed = 1.0f;
    public JumpMeterUI jumpMeterUI;
    private float jumpMeter = Mathf.Clamp(1, 0, 100);

    private float jumpForce;

    public bool onJump = false;
    private float chargeStartTime;


    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        // Rotate
        float direction = 0f;
        if (Keyboard.current.aKey.isPressed) direction = -1f;
        if (Keyboard.current.dKey.isPressed) direction = 1f;
        transform.Rotate(0, direction * rotateSpeed * Time.deltaTime, 0);

        if (!onJump && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            chargeStartTime = Time.time;
        }
        if (!onJump && Keyboard.current.spaceKey.isPressed)
        {
            JumpCharge();
        }
        else if (!onJump && Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            Jump();
        }

        jumpMeterUI.SetValue(jumpMeter);
    }

    public void JumpCharge()
    {
        float elapsed = Time.time - chargeStartTime;
        jumpMeter = Mathf.PingPong(elapsed * 50f, 100f);
    }
    public void Jump()
    {
        float force = CalculateForce();
        rb.AddRelativeForce(new Vector3(0, force, -force));
        jumpMeter = 1;
        onJump = true;
    }

    public float CalculateForce()
    {
        float jumpAccel = jumpMeter * jumpPower; //a
        jumpForce = rb.mass * jumpAccel; // F = m x a
        Debug.Log($"Mass:{rb.mass} Accel:{jumpAccel} JumpForce: {jumpForce}");
        return jumpForce; // F
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onJump = false;
        }
    }

}
