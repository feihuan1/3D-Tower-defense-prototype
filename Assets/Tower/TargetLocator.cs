using System;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileparticles;
    [SerializeField] float range = 15f;

    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        } else {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emmissionModule = projectileparticles.emission;
        emmissionModule.enabled = isActive;
    }
}
