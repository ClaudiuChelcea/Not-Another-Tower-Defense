using UnityEngine;

namespace Units.Archer
{
    public class ArrowController : MonoBehaviour, IDamageDealer
    {
        private Transform target;
        [SerializeField] private float power = 5f;

        public IHealthContainer Target => target.GetComponent<IHealthContainer>();

        public float Power => power;

        public float arrowSpeed = 100f;

        public void Seek(Transform _target)
        {
            target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = arrowSpeed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

        void HitTarget()
        {
            DealDamage();
            Destroy(gameObject);
        }

        public void DealDamage()
        {
            if (Target == null)
            {
                Destroy(target.gameObject);
            }
            else
            {
                Target.TakeDamage(Power);
            }
        }
    }
}