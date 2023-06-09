using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject endScreen;

    public int GetPlayerHealth()
    {
        return health;
    }

    public void DecreaseHealth()
    {
        health--;

        if (health <= 0 )
        {
            GameManager.Instance.isGameOver = true;
            endScreen.SetActive(true);
        }
    }
}
