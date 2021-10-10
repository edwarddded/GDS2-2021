using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject audiomangaer = GameObject.Find("AudioManager").gameObject;
            if (audiomangaer != null)
            {
                Destroy(audiomangaer);
                SceneManager.LoadScene(4);
            }
            
        }
    }
}
