using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour {

    private Transform targetTransform;
    private int waypointIndex = 0;

    private EnemyScript enemy;
    // Use this for initialization
    private void Start()
    {
        enemy = GetComponent<EnemyScript>();
        targetTransform = WaypointsScript.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = targetTransform.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetTransform.position) < 0.4)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= WaypointsScript.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        targetTransform = WaypointsScript.waypoints[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawnerScript.EnemiesAlive--;
        Destroy(gameObject);
    }
}
