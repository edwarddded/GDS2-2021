using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalScenebutton : MonoBehaviour
{
    private GameObject AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<AudioManager>().Play("Survival");

    }
    public void MenuButton()
    {
        AudioManager = GameObject.Find("AudioManager").gameObject;
        if (AudioManager != null)
        {
            Destroy(AudioManager);
            SceneManager.LoadScene(0);
        }

    }

}
