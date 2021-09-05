using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
            Debug.Log("Material detected");
            uiObject.SetActive(true);
            
        }


       
    }
    private void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
    }

}
