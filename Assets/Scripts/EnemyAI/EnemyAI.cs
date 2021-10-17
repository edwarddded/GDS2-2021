using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public float movespeed = 6f;
    private Rigidbody rb;
    private Vector3 movement;
    public float howclose;

    public float EnemyHealth;
    public GameObject MaterialOfEnemy;
    //Enemy Explosion
    public GameObject exp;
    public float expForce, radius;

    private Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        rb = this.GetComponent<Rigidbody>();
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
        }
    }

  
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

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * movespeed * Time.deltaTime));

    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (distance<= howclose)
        {
            Ani.SetBool("Run", true);
            moveCharacter(movement);
        }
        else
        {
            Ani.SetBool("Run", false);
        }
       
    }
    void Update()
    {
        //FollowPlayer();
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (distance <= howclose)
        {
            Vector3 direction = player.position - transform.position;
            gameObject.transform.forward = direction;
            direction.Normalize();
            movement = direction;
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
