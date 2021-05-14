using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Transform target;
    private int wavepointIndex = 0;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }
    private void Update()
    {
        transform.LookAt(Waypoints.waypoints[wavepointIndex]);
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            PathEnd();
            return;
        }
        ++wavepointIndex;
        target = Waypoints.waypoints[wavepointIndex];
    }
    private void PathEnd()
    {
        --PlayerStats.Lives;
        --WaveSpawner.EnemiesAlive;
        Destroy(gameObject);
    }
}