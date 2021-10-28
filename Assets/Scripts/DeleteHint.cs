using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHint : MonoBehaviour
{

    public GameObject missionHint1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BoxCollider collider = gameObject.GetComponent<BoxCollider>();
            collider.enabled = false;
            Destroy(missionHint1);


        }
    }
}
