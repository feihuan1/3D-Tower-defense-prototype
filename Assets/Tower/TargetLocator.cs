using System;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;

    Transform target;

    void Start()
    {
        target = FindFirstObjectByType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
  
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
