using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FlllowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FlllowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endtPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endtPosition);

            while (travelPercent < 1)
            {
                travelPercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endtPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

}
