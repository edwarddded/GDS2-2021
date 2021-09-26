using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBall : MonoBehaviour
{
    public float speed = 1000f;
    public float damage;
    private Rigidbody RG;
    // Start is called before the first frame update
    void Start()
    {
        RG = gameObject.GetComponent<Rigidbody>();
        RG.AddForce(transform.forward * speed);
        Destroy(gameObject, 5);
    }

}
