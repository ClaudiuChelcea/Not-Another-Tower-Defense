using UnityEngine;

[RequireComponent(typeof(IFollower))]
public class PathFollower : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Path path;
    private int waypointIndex = 0;

    private IFollower followController;


    private void Start()
    {
        target = path.points[0];
        followController = GetComponent<IFollower>();
    }

    private void Update()
    {
        if (followController.Target != null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * followController.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= path.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = path.points[waypointIndex];
    }
}