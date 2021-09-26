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
    public float EnemyHealth;
    public GameObject MaterialOfEnemy;
    //Enemy Explosion
    public GameObject exp;
    public float expForce, radius;

    private Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Ani = gameObject.GetComponent<Animator>();
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
            FindObjectOfType<AudioManager>().Play("Hurt");
        }
        // The damage that bullet casue
        if (other.gameObject.tag == "Bullet")
        {
            float CauseDamage = other.gameObject.GetComponent<Bullets>().damage;
            EnemyHealth -= CauseDamage;
            KnockBack();
            Destroy(other.gameObject);
        }
        //The damage that grenade cause
        if (other.gameObject.tag =="Grenade")
        {
            float Causedamage = other.gameObject.GetComponent<Grenade>().damage;
            EnemyHealth -= Causedamage;
        }
        if (other.gameObject.tag == "Megaball")
        {
            float Causedamage = other.gameObject.GetComponent<MegaBall>().damage;
            EnemyHealth -= Causedamage;
            if (moveSpeed >=2)
            {
                StartCoroutine(slowdown());
            } 
        }
    }

    IEnumerator slowdown()
    {
        moveSpeed = moveSpeed / 2;
        Debug.Log(moveSpeed);
        yield return new WaitForSeconds(4);
        moveSpeed = moveSpeed * 2;
        Debug.Log(moveSpeed);
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
            Ani.SetBool("Run", true);
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
