using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public GameObject[] material;
    // Start is called before the first frame update
    void Start()
    {
        int numberOfMaterial = Random.Range(20, 50);
        for (int i = 0; i < numberOfMaterial; i++)
        {
            float x = Random.Range(0, 100);
            float z = Random.Range(0, 100);
            Instantiate(material[Random.Range(0, material.Length)], new Vector3(x, 20, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
