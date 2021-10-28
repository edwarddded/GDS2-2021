using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndcutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Controller());
    }
    IEnumerator Controller()
    {
        yield return new WaitForSeconds(22f);
        SceneManager.LoadScene(6);
    }
}
