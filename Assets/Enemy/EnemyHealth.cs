using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amoumt to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoint = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }

    private void Start() 
    {
        enemy = GetComponent<Enemy>();
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
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
            
        }
    }
}
