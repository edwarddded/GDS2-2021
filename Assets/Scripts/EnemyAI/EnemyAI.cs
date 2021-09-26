using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Enemy Movement
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float howClose;
    public int EnemyHealth;
    private int BulletDamage = 1;
    public GameObject MaterialOfEnemy;
    //Enemy Explosion
    public GameObject exp;
    public float expForce, radius;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            KnockBack();
            Instantiate(MaterialOfEnemy, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            EnemyHealth -= BulletDamage;
            KnockBack();
            Destroy(other.gameObject);
        }
    }
    //Explosion knockBlack
    void KnockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howClose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
        if (EnemyHealth <=0)
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            Instantiate(MaterialOfEnemy, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }


}
