using Units;
using UnityEngine;

public class FollowTarget : MonoBehaviour, IFollower
{
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float speed;
    [SerializeField] private AwarenessController awarenessController;

    private void OnEnable()
    {
        awarenessController ??= GetComponent<AwarenessController>();

        if (awarenessController != null)
        {
            awarenessController.OnTargetSpotted += controller => SetTarget(controller.transform);
        }
    }

    private void OnDisable()
    {
        if (awarenessController != null)
        {
            awarenessController.OnTargetSpotted -= (controller => SetTarget(controller.transform));
        }
    }

    public Transform Target
    {
        get => target;
        protected set => target = value;
    }

    public float StoppingDistance
    {
        get => stoppingDistance;
        protected set => stoppingDistance = value;
    }

    public float Speed
    {
        get => speed;
        protected set => speed = value;
    }

    public void SetTarget(Transform newTarget)
    {
        print($"SetTarget called. New Target = {newTarget.name}");
        Target = newTarget;
    }

    private void Update()
    {
        if (Target == null)
        {
            return;
        }

        if (Vector3.Distance(Target.position, transform.position) < StoppingDistance)
        {
            Explode();
            return;
        }

        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
    }

    void Explode()
    {
        if(Target.tag == "Unit")
            Target.GetComponent<HealthController>().TakeDamage(300f);
        Destroy(this.gameObject);
    }
}
