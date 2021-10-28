using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void GetNextLine()
    {
        DialogueManager.instance.DequeueDialogue();
    }
}
