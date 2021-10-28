using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueBase Dialogue;
    public GameObject TriggerObejct;


    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(Dialogue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerDialogue();
            Destroy(TriggerObejct);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TriggerDialogue();
        //}
    }
}
