using System.Collections;
using System.Collections.Generic;
using Units.Archer;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private Transform target;
    private Animator animator;

    [Header("Attributes")]
    public float range = 40f;
    public float fireRate = 0.2f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    private Unit unitStats;
    public float smoothRotationSpeed = 10f;

    public string enemyTag = "Enemy";
    private Transform spine;

    public GameObject arrowPrefab;
    public Transform firepoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        unitStats = GetComponent<Unit>();
        spine = Utility.RecursiveFindChild(transform.root, "Spine");
        firepoint = Utility.RecursiveFindChild(transform.root, "Firepoint");
        animator = GetComponent<Animator>();
        animator.GetBehaviour<DrawToRelease>().timeToFire = true;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range && 
            nearestEnemy.GetComponent<EnemyStats>().towerSide == unitStats.towerSide)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        RotateToEnemy();
        Fire();
    }

    private void RotateToEnemy()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        spine.rotation = Quaternion.Euler(0, rotation.y - 90, -rotation.x - 90);
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Fire()
    {
        if (fireCountdown <= 0f)
        {
            animator.Play("ArcherDraw");
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    public void ShootArrow() //Called in animation event
    {
        GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        ArrowController arrowController = arrowGO.GetComponent<ArrowController>();

        if (arrowController != null)
            arrowController.Seek(target);
    }
}
