using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> Sentences;
    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
    }
}

    
