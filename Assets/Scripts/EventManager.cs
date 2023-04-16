using System;

public static class EventManager
{
    public static event Action OnPlayerDied;
    public static void Fire_OnPlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public static event Action OnPlayerSpawn;
    public static void Fire_OnPlayerSpawn()
    {
        OnPlayerSpawn?.Invoke();
    }
}
