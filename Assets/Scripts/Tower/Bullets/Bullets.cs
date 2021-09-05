using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float speed = 1000f;
    private Rigidbody rigi;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        rigi.AddForce(transform.forward * speed);
        Destroy(gameObject, 5f);
    }



}
