using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTIme = 1f;

    void Start()
    {
        StartCoroutine(FlllowPath());
    }

    IEnumerator FlllowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTIme);
        }
    }

}
