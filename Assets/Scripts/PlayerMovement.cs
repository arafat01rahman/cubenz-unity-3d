using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardForce = 2000f;
    public float SidewaysForce = 500f;

    void FixedUpdate()
    {
        // Always move forward
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

        // --- KEYBOARD INPUT (PC) ---
        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed)
            {
                MoveRight();
            }
            if (Keyboard.current.aKey.isPressed)
            {
                MoveLeft();
            }
        }

        // --- TOUCH INPUT (ANDROID) ---
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

            // Check if touch is on the right or left half of the screen
            if (touchPos.x > Screen.width / 2)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }

        // --- FALL OFF CHECK ---
        if (rb.position.y < -1f)
        {
            // Finding the GameManager to trigger EndGame
            Object.FindFirstObjectByType<GameManager>().EndGame();
        }
    }

    // Helper methods to keep the code clean
    void MoveRight()
    {
        rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    void MoveLeft()
    {
        rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}