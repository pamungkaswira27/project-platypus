using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    [SerializeField] float positionPitchFactor;
    [SerializeField] float controlPitchFactor;
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlRollFactor;

    [SerializeField] float xBound;
    [SerializeField] float yBound;

    float horizontalInput;
    float verticalInput;

    float pitch;
    float yaw;
    float roll;

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float xDelta = Time.deltaTime * horizontalInput * movementSpeed;
        float yDelta = Time.deltaTime * verticalInput * movementSpeed;

        float xPos = transform.localPosition.x + xDelta;
        float yPos = transform.localPosition.y + yDelta;

        xPos = Mathf.Clamp(xPos, -xBound, xBound);
        yPos = Mathf.Clamp(yPos, -yBound, yBound);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void RotatePlayer()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalInput * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalInput * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }
}
