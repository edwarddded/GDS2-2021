using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject DialogueBox;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;

    public Queue<DialogueBase.info> dialogueinfo = new Queue<DialogueBase.info>();

    private void Start()
    {
        dialogueinfo = new Queue<DialogueBase.info>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {
        DialogueBox.SetActive(true);
        dialogueinfo.Clear();

        foreach (DialogueBase.info info in db.Dialogueinfo)
        {
            dialogueinfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        //add in code that detects if we here no more dialogue and return
        if (dialogueinfo.Count== 0)
        {
            EndofDialogue();
            return;
        }

        DialogueBase.info info = dialogueinfo.Dequeue();

        dialogueName.text = info.Myname;
        dialogueText.text = info.Mytext;
        dialoguePortrait.sprite = info.portrait;

        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.info info)
    {
        dialogueText.text = "";
        foreach(char c in info.Mytext.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndofDialogue()
    {
        DialogueBox.SetActive(false);
    }
}
