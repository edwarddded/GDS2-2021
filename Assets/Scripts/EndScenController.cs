using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScenController : MonoBehaviour
{
    private GameObject AutoManger;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void MenuButton()
    {
        AutoManger = GameObject.Find("AudioManager").gameObject;
        if (AutoManger != null)
        {
            Destroy(AutoManger);
            SceneManager.LoadScene(0);
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
