using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    [SerializeField] float rollSpeed;
    [SerializeField] float pitchFactor;

    [SerializeField] float xBound;
    [SerializeField] float yBound;

    Health health;

    float horizontalInput;
    float verticalInput;

    void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    void Update()
    {
        MovePlayer();
        RollPlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health.DecreaseHealth();

            if (!GameManager.Instance.isGameOver)
            {
                EventManager.Fire_OnPlayerDied();
            }

            GameManager.Instance.isPlayerDie = true;
            Destroy(gameObject);
        }
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float xDelta = Time.deltaTime * horizontalInput * movementSpeed;
        float yDelta = Time.deltaTime * verticalInput * movementSpeed;

        float xPos = transform.position.x + xDelta;
        float yPos = transform.position.y + yDelta;

        xPos = Mathf.Clamp(xPos, -xBound, xBound);
        yPos = Mathf.Clamp(yPos, -yBound, yBound);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    void RollPlayer()
    {
        float roll = rollSpeed * horizontalInput;
        float pitch = pitchFactor * verticalInput;
        transform.rotation = Quaternion.Euler(pitch, transform.rotation.y, roll);
    }
}
