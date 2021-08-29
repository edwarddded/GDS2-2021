using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        if (Input.GetKeyDown("e") && distance <2)
        {
            Debug.Log(this + "been picked");
            Destroy(this.gameObject);
        }
    }

}
