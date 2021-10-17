using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDayNightController : MonoBehaviour
{
    public bool IsCutscenePlaying = false;
    public GameObject Cutscene1, Cutscene2, Cutscene3, Cutscene4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cutscene1.activeInHierarchy||Cutscene2.activeInHierarchy||Cutscene3.activeInHierarchy||Cutscene4.activeInHierarchy)
        {
            IsCutscenePlaying = true;
        }
        else
        {
            IsCutscenePlaying = false;
        }
    }
}
