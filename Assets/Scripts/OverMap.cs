using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverMap : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag =="Player")
        {
            SceneManager.LoadScene(3);
            Debug.Log("You dead");
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
