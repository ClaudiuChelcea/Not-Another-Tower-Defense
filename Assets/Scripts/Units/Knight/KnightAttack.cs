using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    private Transform target;
    private Animator animator;

    [Header("Attributes")]
    public float range = 2f;

    [Header("Unity Setup Fields")]

    private Unit unitStats;
    public float smoothRotationSpeed = 10f;

    public string enemyTag = "Enemy";


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        unitStats = GetComponent<Unit>();
        animator = GetComponent<Animator>();
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

        if (nearestEnemy != null && shortestDistance <= range)
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
        StartCoroutine(SwordAttack());
    }

    private void RotateToEnemy()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    IEnumerator SwordAttack()
    {
        animator.Play("KnightAttack");
        yield return new WaitForSeconds(1);
    }
}
