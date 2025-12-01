// MARIANO CODUTTI ALARCON
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform rotationPivot;
    [SerializeField] private int damageToBase = 1;
    [SerializeField] private Vector3 spawnOffset;


    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1f;

    private Transform[] path;
    private Transform waypointTarget;
    private int waypointIndex = 0;


    private void Start()
    {
        if (path == null || path.Length == 0)
        {
            Debug.LogError("ENEMY SPAWNED WITHOUT PATH ASSIGNED!");
            Destroy(gameObject);
            return;
        }

        waypointTarget = path[0];
    }

    private void Update()
    {
        MoveAlongPath();
    }


    private void MoveAlongPath()
    {
        // Move to next waypoint.
        Vector3 moveDirection = waypointTarget.position - transform.position;
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // Smooth turning.
        if (rotationPivot != null && moveDirection != Vector3.zero)
        {
            float turnSmooth = 20f;
            rotationPivot.forward = Vector3.Lerp(
                rotationPivot.forward,
                moveDirection,
                Time.deltaTime * turnSmooth);
        }

        // Get next waypoint.
        if (Vector3.Distance(transform.position, waypointTarget.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= path.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        waypointTarget = path[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.playerHealth -= damageToBase;
        FindAnyObjectByType<BaseUI>().UpdateHealthBar();

        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }


    public void SetPath(Transform[] _assignedPath)
    {
        path = _assignedPath;
    }
}
