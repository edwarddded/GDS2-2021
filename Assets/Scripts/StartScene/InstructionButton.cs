using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void TutorialButton()
    {
        SceneManager.LoadScene(3);
    }
    public void SkiptoGame()
    {
        SceneManager.LoadScene(4);
    }
}
