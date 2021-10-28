using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float speed = 1000f;
    private Rigidbody RG;
    public float radius;
    public float expForce;
    public GameObject exp;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        RG = gameObject.GetComponent<Rigidbody>();
        RG.AddForce(transform.forward * speed);
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            Destroy(gameObject);
            KnockBack();
        }
    }
    //private void OnCollisionEnter(Collision other)
    //{
        
    //}
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
}
