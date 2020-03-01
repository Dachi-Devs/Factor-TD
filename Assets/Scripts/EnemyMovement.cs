using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;
    public GameManager gm;

    public float rotSpeed = 10f;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        enemy = GetComponent<Enemy>();
        target = gm.enemyPath[1];
    }

    void Update()
    {
        MoveToWaypoint();

        if (Vector3.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= gm.enemyPath.Length - 1)
        {
            EndPath();
            return;
        }
        else
        {
            waypointIndex++;
            target = gm.enemyPath[waypointIndex];
        }
    }

    void EndPath()
    {
        FindObjectOfType<PlayerStats>().TakeDamage(enemy.value);
        //WaveSpawner.enemyCount--;
        Destroy(gameObject);
    }
}
