using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileLifetime;
    [SerializeField] float fireRate;
    [SerializeField] Transform leftShootPoint;
    [SerializeField] Transform rightShootPoint;

    float delay = 3f;

    void Start()
    {
        Invoke(nameof(Fire), delay);
    }

    void Fire()
    {
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            GameObject leftProjectile = Instantiate(projectilePrefab, leftShootPoint.position, Quaternion.identity);
            GameObject rightProjectile = Instantiate(projectilePrefab, rightShootPoint.position, Quaternion.identity);

            leftProjectile.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileSpeed;
            rightProjectile.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileSpeed;

            Destroy(leftProjectile, projectileLifetime);
            Destroy(rightProjectile, projectileLifetime);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
