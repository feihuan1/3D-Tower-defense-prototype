using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 5;
    [SerializeField] int currentHitPoint = 0;

    void Start()
    {
        currentHitPoint = MaxHitPoints;
    }

    private void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        if(currentHitPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
