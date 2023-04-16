using TMPro;
using UnityEngine;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    Health health;

    void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    void Update()
    {
        DisplayHealth();
    }

    void DisplayHealth()
    {
        health = FindObjectOfType<Health>();
        healthText.text = health.GetPlayerHealth().ToString();
    }
}
