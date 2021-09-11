using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(IFollower))]
public class PathFollower : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Path path;
    private int waypointIndex = 0;

    private IFollower followController;
    public static int receive_lives;
    public TextMeshProUGUI lives_text;


    private void Start()
    {
        target = path.points[0];
        followController = GetComponent<IFollower>();
        receive_lives = GameBalance.lives;
        lives_text.text = receive_lives.ToString();
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
            HitCrystal();
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = path.points[waypointIndex];
    }

    void HitCrystal()
    {
        receive_lives = receive_lives - 2;
        lives_text.text = receive_lives.ToString();
    }
}
