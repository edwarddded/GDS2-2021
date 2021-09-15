using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private GameObject currentTarget;
    public Transform TurretHead;

    [Header("Tower Attack")]
    public float attackDist;
    public float shotCoolDown;
    private float timer;
    public float lookSpeed = 2f;

    public bool showRange = false;

    public TurretShoot_Base shotScript;

    private void Start()
    {
        InvokeRepeating("CheckForTarget", 0, 0.5f);
        shotScript = GetComponent<TurretShoot_Base>();
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            FollowTarget();
        }

        timer += Time.deltaTime;
        if (timer >= shotCoolDown)
        {
            if (currentTarget != null)
            {
                timer = 0;
                Shoot();
            }
        }
    }
    private void CheckForTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, attackDist);
        float distAway = Mathf.Infinity;
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].tag == "Enemy" || colls[i].tag == "Enemy2")
            {
                float dist = Vector3.Distance(transform.position, colls[i].transform.position);
                if (dist<distAway)
                {
                    currentTarget = colls[i].gameObject;
                    distAway = dist;
                }
            }
        }
    }

    private void FollowTarget()
    {
        Vector3 targetDir = currentTarget.transform.position - transform.position;
        targetDir.y = 0;
        TurretHead.forward = targetDir;
    }

    private void Shoot()
    {
        shotScript.Shoot(currentTarget);
    }
    private void OnDrawGizmos()
    {
        if (showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
    }
}
