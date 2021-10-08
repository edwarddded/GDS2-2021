using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Setting()
    {
        Debug.Log("Setting Menu");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(3);
    }
    public void SkiptoGame()
    {
        SceneManager.LoadScene(4);
    }
}
