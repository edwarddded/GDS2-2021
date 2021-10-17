using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnenmyController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField] private GameObject currentTarget;
    [SerializeField] public float attackDist;
    public float EnemyHealth;
    public GameObject MaterialOfEnemy;
    public GameObject exp;
    public float expForce, radius;
    public bool showRange = false;
    public Animator Ani;

    public Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        Getreference();
        InvokeRepeating("CheckForTarget", 0, 0.5f);
        Ani = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Tower")
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            //KnockBack();
            Instantiate(MaterialOfEnemy, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Hurt");
        }
        if (other.gameObject.tag == "Bullet")
        {
            float CauseDamage = other.gameObject.GetComponent<Bullets>().damage;
            EnemyHealth -= CauseDamage;
            //KnockBack();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Grenade")
        {
            float Causedamage = other.gameObject.GetComponent<Grenade>().damage;
            EnemyHealth -= Causedamage;
        }
        if (other.gameObject.tag == "Megaball")
        {
            float Causedamage = other.gameObject.GetComponent<MegaBall>().damage;
            EnemyHealth -= Causedamage;
        }
    }

    private void Getreference()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void MoveToTarget()
    {
        agent.SetDestination(currentTarget.transform.position);
    }

    private void RotateToTarget()
    {
        //transform.LookAt(target);

        Vector3 direction = currentTarget.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
    private void CheckForTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, attackDist);
        float disAway = Mathf.Infinity;
        for (int i  = 0; i < colls.Length; i++)
        {
            if (colls[i].tag == "Player" || colls[i].tag =="Tower")
            {
                float dist = Vector3.Distance(transform.position, colls[i].transform.position);
                if (dist < disAway)
                {
                    currentTarget = colls[i].gameObject;
                    disAway = dist;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentTarget!=null)
        {
            Ani.SetBool("Run", true);
            MoveToTarget();
        }
        else
        {
            Ani.SetBool("Run", false);
        }
        if (EnemyHealth <= 0)
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            
            Instantiate(MaterialOfEnemy, tf.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }
}
