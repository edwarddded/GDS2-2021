﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Transform tran = gameObject.GetComponent<Transform>();
        tran.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
