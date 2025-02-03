using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;

    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    IEnumerator spawnRoutine() 
    {
        
        while(true)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }


}
