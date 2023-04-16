using Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followCam;

    void OnEnable()
    {
        EventManager.OnPlayerSpawn += SetFollowPlayer;
    }

    void OnDisable()
    {
        EventManager.OnPlayerSpawn -= SetFollowPlayer;
    }

    void SetFollowPlayer()
    {
        Transform player = FindObjectOfType<PlayerController>().transform;
        followCam.Follow = player;
    }
}
